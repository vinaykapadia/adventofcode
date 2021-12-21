using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace AdventOfCode._2015.Day08;

[ProblemName("Matchsticks")]      
internal class Solution : ISolver {
    public static int PartBSolution { get; set; }

    public object PartOne(string input) {
        var codeCount = 0;
        var charCount = 0;
        var partBCharCount = 0;

        foreach (var line in input.Split('\n'))
        {
            partBCharCount += 2;
            partBCharCount += line.Length;
            partBCharCount += line.Count(x => x is '\\' or '"');

            codeCount += 2;
            var i = 1;
            while (i < line.Length - 1)
            {
                codeCount++;
                charCount++;
                if (line[i] == '\\')
                {
                    if (line[i + 1] == 'x')
                    {
                        i += 3;
                        codeCount += 3;
                    }
                    else
                    {
                        i++;
                        codeCount++;
                    }
                }
                i++;
            }
        }

        PartBSolution = partBCharCount - codeCount;
        return codeCount - charCount;
    }

    public object PartTwo(string input) {
        return PartBSolution;
    }
}
