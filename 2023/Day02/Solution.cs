using System.Text.RegularExpressions;

namespace AdventOfCode._2023.Day02;

[ProblemName("Cube Conundrum")]      
internal class Solution : ISolver
{
    public object PartOne(string input) =>
        (from line in input.Lines()
            let colon = line.IndexOf(':')
            let gameNum = int.Parse(line[5..colon])
            where !Regex.Matches(line, "\\d+ red").Any(x => int.Parse(Regex.Match(x.Value, "\\d+").Value) > 12)
            where !Regex.Matches(line, "\\d+ green").Any(x => int.Parse(Regex.Match(x.Value, "\\d+").Value) > 13)
            where !Regex.Matches(line, "\\d+ blue").Any(x => int.Parse(Regex.Match(x.Value, "\\d+").Value) > 14)
            select gameNum)
        .Sum();

    public object PartTwo(string input) =>
        (from line in input.Lines()
            let bluePower = Regex.Matches(line, "\\d+ blue").Max(x => int.Parse(Regex.Match(x.Value, "\\d+").Value))
            let redPower = Regex.Matches(line, "\\d+ red").Max(x => int.Parse(Regex.Match(x.Value, "\\d+").Value))
            let greenPower = Regex.Matches(line, "\\d+ green").Max(x => int.Parse(Regex.Match(x.Value, "\\d+").Value))
            select bluePower * redPower * greenPower)
        .Sum();
}
