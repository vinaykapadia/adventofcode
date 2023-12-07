using System.Text.RegularExpressions;

namespace AdventOfCode._2023.Day06;

[ProblemName("Wait For It")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        var lines = input.Lines();
        var times = Regex.Matches(lines[0], "\\d+").Select(x => int.Parse(x.Value)).ToList();
        var records = Regex.Matches(lines[1], "\\d+").Select(x => int.Parse(x.Value)).ToList();

        var total = 1;

        for (var i = 0; i < times.Count; i++)
        {
            total *= GetWays(records[i], times[i]);
        }

        return total;
    }

    public object PartTwo(string input)
    {
        var lines = input.Lines();
        var time = long.Parse(Regex.Match(lines[0].Replace(" ", ""), "\\d+").Value);
        var record = long.Parse(Regex.Match(lines[1].Replace(" ", ""), "\\d+").Value);

        return GetWays(record, time);
    }
    
    private static int GetWays(long record, long time)
    {
        var ways = 0;

        for (var i = 0; i < time; i++)
        {
            if (i * (time - i) > record)
            {
                ways++;
            }
        }

        return ways;
    }
}
