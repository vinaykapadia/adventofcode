using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace AdventOfCode._2015.Day02;

[ProblemName("I Was Told There Would Be No Math")]      
internal class Solution : Solver {

    public object PartOne(string input)
    {
        return input.Split('\n')
            .Select(line => line.Split('x')
                .Select(int.Parse)
                .OrderBy(x => x)
                .ToArray())
            .Select(nums => 3 * nums[0] * nums[1] + 2 * nums[0] * nums[2] + 2 * nums[1] * nums[2])
            .Sum();
    }

    public object PartTwo(string input) {
        return input.Split('\n')
            .Select(line => line.Split('x')
                .Select(int.Parse)
                .OrderBy(x => x)
                .ToArray())
            .Select(nums => 2 * nums[0] + 2 * nums[1] + nums[0] * nums[1] * nums[2])
            .Sum();
    }
}
