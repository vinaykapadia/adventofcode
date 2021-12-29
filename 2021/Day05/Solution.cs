using System.Text.RegularExpressions;

namespace AdventOfCode._2021.Day05;

[ProblemName("Hydrothermal Venture")]      
internal class Solution : ISolver
{
    private readonly List<(int x1, int y1, int x2, int y2)> _lines = new();
    
    public object PartOne(string input)
    {
        foreach (var line in input.Lines())
        {
            var matches = Regex.Matches(line, "\\d+").Select(x => int.Parse(x.Value)).ToArray();
            _lines.Add((matches[0], matches[1], matches[2], matches[3]));
        }

        return CountOverlap(_lines.Where(x => x.x1 == x.x2 || x.y1 == x.y2));
    }

    public object PartTwo(string input) => CountOverlap(_lines);

    private static int CountOverlap(IEnumerable<(int x1, int y1, int x2, int y2)> lines)
    {
        AutoAddingDictionary<string, int> map = new();

        foreach (var (x1, y1, x2, y2) in lines)
        {
            var x = x1;
            var y = y1;
            var xDir = Math.Sign(x2 - x1);
            var yDir = Math.Sign(y2 - y1);

            while (x != x2 || y != y2)
            {
                map[x + "-" + y]++;
                x += xDir;
                y += yDir;
            }

            map[x + "-" + y]++;
        }

        return map.Values.Count(x => x > 1);
    }
}
