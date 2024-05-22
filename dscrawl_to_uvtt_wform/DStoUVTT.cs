using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using static DoorFunctions;
using static GeometryFunctions;


class DStoUVTT
{
    public class Global
    {
        public static Coordinate origin_offset = new Coordinate {x = double.MaxValue, y = double.MaxValue};
        public const double SCALE = 0.0277777777777778;
    }

    static JObject ParseMapData(string fileName)
    {
        Console.WriteLine("Parsing map data...");

        using (StreamReader file = new StreamReader(fileName))
        {
            string content = file.ReadToEnd();

            string pattern = @"(?:map)({.*})";
            Match match = Regex.Match(content, pattern);
            string jsonAsString = match.Groups[1].Value;

            if (jsonAsString == "")
            {
                throw new Exception("No map data found in the file.");
            }

            return JObject.Parse(jsonAsString);
        }
    }

    static JObject ParseUvttTemplate()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        Stream stream = assembly.GetManifestResourceStream("dscrawl_to_uvtt_wform.uvtt_template.json");

        JObject mapObject = new JObject();

        if (stream != null)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                mapObject = JObject.Parse(reader.ReadToEnd());
            }
        }
        else
        {
            Console.WriteLine("UvttTemplate could not be found!");
        }

        return mapObject;
    }

    static string ImageAsBase64(string fileName)
    {
        byte[] imageArray = File.ReadAllBytes(fileName);
        return Convert.ToBase64String(imageArray);
    }


    public static void DscrawlToUvtt(string dscrawlFileName, int mapWidth, int mapHeight, int tileSize, string imageFileName)
    {
        Console.WriteLine($"DscrawlFileName: {dscrawlFileName}");
        Console.WriteLine($"MapWidth: {mapWidth}");
        Console.WriteLine($"MapHeight: {mapHeight}");
        Console.WriteLine($"TileSize: {tileSize}");
        Console.WriteLine($"ImageFileName: {imageFileName}");

        var DESCRIPTION = "Convert a DungeonScrawl file to a .dd2vtt file.";
        var VERSION = "1.0.0";

        JObject mapData = ParseMapData(dscrawlFileName);
        var wallids = new List<string>();
        var doorIds = new List<string>();

        GetGeometryIds(mapData, out wallids, out doorIds);

        List<List<Coordinate>> obstructionLines;

        obstructionLines = GeometryToObstructionLines(mapData, wallids);

        JArray portals = GeneratePortals(mapData, doorIds);

        obstructionLines = ScaleAndOffsetCoordinates(obstructionLines);

        JObject mapObject = ParseUvttTemplate();

        mapObject["resolution"]["map_size"]["x"] = mapWidth;
        mapObject["resolution"]["map_size"]["y"] = mapHeight;
        mapObject["resolution"]["pixels_per_grid"] = tileSize;

        mapObject["line_of_sight"] = JArray.FromObject(obstructionLines);
        mapObject["portals"] = portals;

        if (imageFileName != "")
        {
            string image = ImageAsBase64(imageFileName);
            mapObject["image"] = image;
        }

        string json = mapObject.ToString(Formatting.Indented);

        string outPath = Path.Combine(Path.GetDirectoryName(dscrawlFileName), Path.GetFileNameWithoutExtension(dscrawlFileName) + ".dd2vtt");
        File.WriteAllText(outPath, json, encoding: Encoding.UTF8);

        //Console.WriteLine(JsonConvert.SerializeObject(Global.origin_offset));
    }
}
