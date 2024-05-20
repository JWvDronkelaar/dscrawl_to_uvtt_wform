using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

public class GeometryFunctions
{
    public class Coordinate
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    public static List<List<Coordinate>> ScaleAndOffsetCoordinates(List<List<Coordinate>> obstructionLines)
    {
        foreach (var line in obstructionLines)
        {
            foreach (var coordinate in line)
            {
                coordinate.x = (coordinate.x - DStoUVTT.Global.origin_offset.x) * DStoUVTT.Global.SCALE;
                coordinate.y = (coordinate.y - DStoUVTT.Global.origin_offset.y) * DStoUVTT.Global.SCALE;
            }
        }
        return obstructionLines;
    }

    static void UpdateOriginOffset(Coordinate coordinate)
    {
        if (DStoUVTT.Global.origin_offset == null)
        {
            DStoUVTT.Global.origin_offset = new Coordinate { x = coordinate.x, y = coordinate.y };
        }
        else
        {
            DStoUVTT.Global.origin_offset.x = Math.Min(DStoUVTT.Global.origin_offset.x, coordinate.x);
            DStoUVTT.Global.origin_offset.y = Math.Min(DStoUVTT.Global.origin_offset.y, coordinate.y);
        }
    }

    public static List<List<Coordinate>> GeometryContainerToCoordinatesList(JArray geometryContainer)
    {
        List<List<Coordinate>> obstructionLines = new List<List<Coordinate>>();

        foreach (JArray multiline in geometryContainer)
        {
            List<Coordinate> multilineCoordinateList = new List<Coordinate>();

            foreach (JArray coordinatePair in multiline)
            {
                List<double> coordinateList = coordinatePair.ToObject<List<double>>();
                Coordinate coordinate = new Coordinate { x = coordinateList[0], y = coordinateList[1] };
                multilineCoordinateList.Add(coordinate);
                UpdateOriginOffset(coordinate);
            }

            obstructionLines.Add(multilineCoordinateList);
            Console.WriteLine("Added obstruction line.");
        }

        return obstructionLines;
    }

    public static List<List<Coordinate>> GeometryToObstructionLines(JObject mapData, List<string> geometryIds)
    {
        Console.WriteLine("Converting geometry to obstruction lines...");
        JObject geometry = mapData["data"]["geometry"] as JObject;
        List<List<Coordinate>> obstructionLines = new List<List<Coordinate>>();

        foreach (string geometry_id in geometryIds)
        {
            Console.WriteLine($"Processing geometry container '{geometry_id}'...");
            JObject layer_geometry = geometry[geometry_id] as JObject;

            JArray polygonGroup = (JArray)layer_geometry["polygons"][0];
            obstructionLines.AddRange(GeometryContainerToCoordinatesList(polygonGroup));

            JArray polyLineGroup = (JArray)layer_geometry["polylines"];
            obstructionLines.AddRange(GeometryContainerToCoordinatesList(polyLineGroup));
        }

        Console.WriteLine($"{obstructionLines.Count} total obstruction lines generated!");
        return obstructionLines;
    }
    public static void GetGeometryIds(JObject mapData, out List<string> geoWallids, out List<string> geoDoorIds)
    {
        Console.WriteLine("Getting geometry ids... ");
        JObject layers = mapData["state"]["document"]["nodes"].ToObject<JObject>();
        var layerIds = layers.Properties().Select(p => p.Name);

        geoWallids = new List<string>();
        geoDoorIds = new List<string>();
        var tempGeoId = "string";

        foreach (var layerId in layerIds)
        {
            var layer = layers[layerId].ToObject<JObject>();

            var type = layer["type"].ToString();
            var layerName = layer["name"].ToString();

            if (type == "GEOMETRY")
            {
                tempGeoId = layer["geometryId"].ToString();
                if (layerName == "Door geometry")
                {
                    geoDoorIds.Add(tempGeoId);
                    Console.WriteLine($"Door geometry found with geometry ID: {tempGeoId}.");
                }
                else if (layerName != "Stairs geometry")
                {
                    geoWallids.Add(tempGeoId);
                    Console.WriteLine($"Wall geometry found with geometry ID: {tempGeoId}.");
                }
            }
        }

        Console.WriteLine($"{geoWallids.Count} total walls found!");
        Console.WriteLine($"{geoDoorIds.Count} total doors found!");
    }
}


