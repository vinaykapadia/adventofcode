using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2018.Day01;

[ProblemName("Chronal Calibration")]      
internal class Solution : ISolver
{

    public object PartOne(string input) => input.Lines().Sum(int.Parse);
    public object PartTwo(string input)
    {
        var lines = input.Lines();
        int part2 = 0;
        bool found = false;
        int i = 0;
        List<int> seen = new List<int>();

        while (!found)
        {
            part2 += int.Parse(lines[i]);
            if (seen.Contains(part2)) found = true;
            seen.Add(part2);
            i++;
            i %= lines.Length;
        }

        return part2;
    }
}
