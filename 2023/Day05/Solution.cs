namespace AdventOfCode._2023.Day05;

[ProblemName("If You Give A Seed A Fertilizer")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        var lines = input.Lines();
        var steps = new List<List<Map>>
        {
            GetMapData(lines, "seed-to-soil"),
            GetMapData(lines, "soil-to-fertilizer"),
            GetMapData(lines, "fertilizer-to-water"),
            GetMapData(lines, "water-to-light"),
            GetMapData(lines, "light-to-temperature"),
            GetMapData(lines, "temperature-to-humidity"),
            GetMapData(lines, "humidity-to-location")
        };

        var seeds = lines[0].Split(' ').Skip(1).Select(long.Parse).ToList();

        long min = long.MaxValue;
        foreach (var seed in seeds)
        {
            var result = seed;
            foreach (var step in steps)
            {
                var map = step.FirstOrDefault(x => x.SourceStart <= result && x.SourceStart + x.Range >= result);
                result += (map?.DestinationStart - map?.SourceStart) ?? 0;
            }

            if (result < min)
            {
                min = result;
            }
        }

        return min;
    }

    public object PartTwo(string input)
    {
        var lines = input.Lines();
        var steps = new List<List<Map>>
        {
            GetMapData(lines, "seed-to-soil"),
            GetMapData(lines, "soil-to-fertilizer"),
            GetMapData(lines, "fertilizer-to-water"),
            GetMapData(lines, "water-to-light"),
            GetMapData(lines, "light-to-temperature"),
            GetMapData(lines, "temperature-to-humidity"),
            GetMapData(lines, "humidity-to-location")
        };

        var seeds = lines[0].Split(' ').Skip(1).Select(long.Parse).ToList();

        long min = long.MaxValue;
        for(var i = 0; i < seeds.Count; i+=2)
        {
            for (long j = 0; j < seeds[i + 1]; j++)
            {
                var result = seeds[i] + j;
                foreach (var step in steps)
                {
                    var map = step.FirstOrDefault(x => x.SourceStart <= result && x.SourceStart + x.Range >= result);
                    result += (map?.DestinationStart - map?.SourceStart) ?? 0;
                }

                if (result < min)
                {
                    min = result;
                }
            }
        }

        return min;
    }

    private List<Map> GetMapData(string[] lines, string mapType)
    {
        int i = 0;

        while (!lines[i].StartsWith(mapType))
        {
            i++;
        }

        i++;
        var mapList = new List<Map>();

        while (i < lines.Length && lines[i] != "")
        {
            var split = lines[i].Split(' ');
            mapList.Add(new Map
            {
                DestinationStart = long.Parse(split[0]),
                SourceStart = long.Parse(split[1]),
                Range = long.Parse(split[2])
            });
            i++;
        }

        return mapList;
    }

    private class Map
    {
        public long DestinationStart { get; init; }

        public long SourceStart { get; init; }

        public long Range { get; init; }
    }
}
