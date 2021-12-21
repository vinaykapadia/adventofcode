namespace AdventOfCode._2021.Day02;

[ProblemName("Dive!")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        var distance = 0;
        var depth = 0;

        foreach (var line in input.Lines())
        {
            if (line.StartsWith("forward ")) distance += int.Parse(line[8..]);
            if (line.StartsWith("down ")) depth += int.Parse(line[5..]);
            if (line.StartsWith("up ")) depth -= int.Parse(line[3..]);
        }

        return distance * depth;
    }

    public object PartTwo(string input)
    {
        var distance = 0;
        var depth = 0;
        var aim = 0;

        foreach (var line in input.Lines())
        {
            if (line.StartsWith("forward "))
            {
                var x = int.Parse(line[8..]);
                distance += x;
                depth += aim * x;
            }
            if (line.StartsWith("down ")) aim += int.Parse(line[5..]);
            if (line.StartsWith("up ")) aim -= int.Parse(line[3..]);
        }

        return distance * depth;
    }
}
