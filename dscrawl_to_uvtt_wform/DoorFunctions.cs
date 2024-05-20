using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using static GeometryFunctions;

public class DoorFunctions
{
    public static string GetDoorType(JArray polylines, JArray polygons)
    {
        int polylinesCount = polylines.Count;
        int polygonsCount = polygons.Count;

        int polylinesPointCount = 0;
        foreach (JArray polyline in polylines)
        {
            polylinesPointCount += polyline.Count;
        }

        int polygonsPointCount = 0;
        foreach (JArray polygon in polygons[0])
        {
            polygonsPointCount += polygon.Count;
            // rectangle with small wall segments on either end
            if (polylinesCount == 2
                && polygonsCount == 1
                && polylinesPointCount == 4
                && (polygonsPointCount == 4 || polygonsPointCount == 5))
            {
                return "A";
            }
        }

        // just a plain rectangle
        if (polylinesCount == 0
            && polygonsCount == 1)
        {
            return "B";
        }

        return "0";
    }

    public static List<Coordinate> CalculateObstructionLineForDoorA(JArray doorPolylines, JArray doorPolygons)
    {
        Console.WriteLine("Calculating obstruction line for door A...");
        List<Coordinate> obstructionLine = new List<Coordinate>();

        Coordinate start = new Coordinate
        {
            x = (double)doorPolylines[0][0][0],
            y = (double)doorPolylines[0][0][1]
        };
        obstructionLine.Add(start);

        Coordinate end = new Coordinate
        {
            x = (double)doorPolylines[1][1][0],
            y = (double)doorPolylines[1][1][1]
        };
        obstructionLine.Add(end);

        return obstructionLine;
    }

    public static List<Coordinate> CalculateObstructionLineForDoorB(JArray door_polylines, JArray door_polygons)
    {
        Console.WriteLine("Calculating obstruction line for door B...");
        JArray polygon = (JArray)door_polygons[0];

        List<Coordinate> obstructionLine = new List<Coordinate>();

        Coordinate long_edge_start = new Coordinate { x = (double)polygon[0][0], y = (double)polygon[0][1] };
        Coordinate long_edge_end = new Coordinate { x = (double)polygon[1][0], y = (double)polygon[1][1] };


        Coordinate offset = new Coordinate
        {
            x = ((double)polygon[1][0] - (double)polygon[2][0]) / 2,
            y = ((double)polygon[1][1] - (double)polygon[2][1]) / 2
        };

        Coordinate midline_start = new Coordinate { x = long_edge_start.x - offset.x, y = long_edge_start.y - offset.y };
        Coordinate midline_end = new Coordinate { x = long_edge_end.x - offset.x, y = long_edge_end.y - offset.y };

        obstructionLine.Add(midline_start);
        obstructionLine.Add(midline_end);

        return obstructionLine;
    }

    public static List<List<Coordinate>> ConvertDoorsToObstructionLines(JObject mapData, List<string> geometryIds)
    {
        Console.WriteLine("Converting doors to obstruction lines...");
        JObject geometry = mapData["data"]["geometry"] as JObject;
        List<List<Coordinate>> obstructionLines = new List<List<Coordinate>>();

        foreach (string geometry_id in geometryIds)
        {
            Console.WriteLine($"Processing door geometry container '{geometry_id}'...");

            JObject layer_geometry = geometry[geometry_id] as JObject;

            JArray doorPolylines = (JArray)layer_geometry["polylines"];
            JArray doorPolygons = (JArray)layer_geometry["polygons"][0];

            string doorType = GetDoorType(doorPolylines, doorPolygons);


            List<Coordinate> doorObstructionLine;

            if (doorType == "A")
            {
                doorObstructionLine = CalculateObstructionLineForDoorA(doorPolylines, doorPolygons);
            }
            else if (doorType == "B")
            {
                doorObstructionLine = CalculateObstructionLineForDoorB(doorPolylines, doorPolygons);
            }
            else
            {
                continue;
            }

            obstructionLines.Add(doorObstructionLine);
        }

        Console.WriteLine($"{obstructionLines.Count} total door obstruction lines generated!");
        return obstructionLines;
    }

    public static JArray GeneratePortals(JObject mapData, List<string> geometryIds)
    {
        Console.WriteLine($"Generating portals from {geometryIds.Count} door entities...");
        List<List<Coordinate>> doorObstructionLines = ConvertDoorsToObstructionLines(mapData, geometryIds);
        doorObstructionLines = ScaleAndOffsetCoordinates(doorObstructionLines);

        Console.WriteLine("Door obstruction lines");
        Console.WriteLine(JsonConvert.SerializeObject(doorObstructionLines));

        JArray portals = new JArray();

        foreach (List<Coordinate> line in doorObstructionLines)
        {
            JObject portal = new JObject(
                new JProperty("position",
                    new JObject(
                        new JProperty("x", 0),
                        new JProperty("y", 0)
                    )
                ),
                new JProperty("bounds",
                    new JArray(
                        new JObject(
                            new JProperty("x", line[0].x),
                            new JProperty("y", line[0].y)
                        ),
                        new JObject(
                            new JProperty("x", line[1].x),
                            new JProperty("y", line[1].y)
                        )
                    )
                ),
                new JProperty("rotation", 0),
                new JProperty("closed", true),
                new JProperty("freestanding", false)
            );
            portals.Add(portal);
        }

        return portals;
    }
}
