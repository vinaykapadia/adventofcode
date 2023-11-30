using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode._2021.Day14;

[ProblemName("Extended Polymerization")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        Dictionary<string, string> map = new();
        var lines = input.Lines();
        var poly = lines[0];
        for (var i = 2; i < lines.Length; i++)
        {
            var parts = lines[i].Replace(" -> ", "-").Split('-');
            var newString = string.Concat(parts[0][0], parts[1]);
            map.Add(parts[0], newString);
        }

        for (var step = 0; step < 10; step++)
        {
            StringBuilder sb = new();
            for (int i = 0; i < poly.Length - 1; i++)
            {
                var key = poly[i..(i + 2)];
                if (map.ContainsKey(key))
                {
                    sb.Append(map[key]);
                }
                else
                {
                    sb.Append(key[0]);
                }
            }

            sb.Append(poly[^1..]);
            poly = sb.ToString();
        }

        var groups = poly.GroupBy(x => x).Select(y => y.Count()).ToList();

        return groups.Max() - groups.Min();
    }

    public object PartTwo(string input)
    {
        return 0; // this isn't working
        Dictionary<string, string> map = new();
        var lines = input.Lines();
        var poly = lines[0];
        for (var i = 2; i < lines.Length; i++)
        {
            var parts = lines[i].Replace(" -> ", "-").Split('-');
            var newString = string.Concat(parts[0][0], parts[1]);
            map.Add(parts[0], newString);
        }

        Dictionary<string, string> secondMap = new();

        foreach (var mapping in map)
        {
            string newString = RunMap(mapping.Key, map);
            secondMap.Add(mapping.Key, newString);
        }

        return 0;
    }

    private static string RunMap(string poly, Dictionary<string, string> map)
    {
        for (var step = 0; step < 40; step++)
        {
            StringBuilder sb = new();
            for (int i = 0; i < poly.Length - 1; i++)
            {
                var key = poly[i..(i + 2)];
                if (map.ContainsKey(key))
                {
                    sb.Append(map[key]);
                }
                else
                {
                    sb.Append(key[0]);
                }
            }

            sb.Append(poly[^1..]);
            poly = sb.ToString();

            Console.WriteLine($"Step {step}");
        }

        return poly;
    }
}
