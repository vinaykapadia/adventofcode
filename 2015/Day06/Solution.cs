using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace AdventOfCode._2015.Day06;

[ProblemName("Probably a Fire Hazard")]      
internal class Solution : ISolver {

    public object PartOne(string input) {
        var lights = new bool[1000000];

        foreach (var line in input.Lines())
        {
            var coords = Regex.Matches(line, "\\d+").Select(x => int.Parse(x.Value)).ToArray();
            for (int i = coords[0]; i <= coords[2]; i++)
            for (int j = coords[1]; j <= coords[3]; j++)
            {
                if (line.StartsWith("turn on")) lights[i*1000+j] = true;
                else if (line.StartsWith("turn off")) lights[i*1000+j] = false;
                else lights[i*1000+j] = !lights[i*1000+j];
            }
        }

        return lights.Count(x => x);
    }

    public object PartTwo(string input) {
        var lights = new int[1000000];

        foreach (var line in input.Lines())
        {
            var coords = Regex.Matches(line, "\\d+").Select(x => int.Parse(x.Value)).ToArray();
            for (int i = coords[0]; i <= coords[2]; i++)
            for (int j = coords[1]; j <= coords[3]; j++)
            {
                if (line.StartsWith("turn on")) lights[i * 1000 + j]++;
                else if (line.StartsWith("turn off"))
                {
                    if (lights[i * 1000 + j] > 0)
                        lights[i * 1000 + j]--;
                }
                else lights[i * 1000 + j] = lights[i * 1000 + j] += 2;
            }
        }

        return lights.Sum();
    }
}
