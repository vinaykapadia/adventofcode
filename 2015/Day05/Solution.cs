using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace AdventOfCode._2015.Day05;

[ProblemName("Doesn't He Have Intern-Elves For This?")]      
internal class Solution : Solver {

    public object PartOne(string input) => input.Split('\n').Count(x => PartA1(x) && PartA2(x) && PartA3(x));

    public object PartTwo(string input) => input.Split('\n').Count(x => PartB1(x) && PartB2(x));

    // doesn't contain these strings
    private static bool PartA1(string s)
    {
        return !(s.Contains("ab") || s.Contains("cd") || s.Contains("pq") || s.Contains("xy"));
    }

    // contains a letter twice in a row
    private static bool PartA2(string s)
    {
        for (var i = 0; i < s.Length - 1; i++)
        {
            if (s[i] == s[i + 1])
            {
                return true;
            }
        }

        return false;
    }

    // contains at least 3 vowels
    private static bool PartA3(string s)
    {
        return Regex.Matches(s, "[aeiou]").Count >= 3;
    }

    // contains pair of letters at least twice
    private static bool PartB1(string s)
    {
        for (var i = 0; i < s.Length - 2; i++)
        {
            var find = s[i..(i + 2)];
            if (s[(i + 2)..].Contains(find))
            {
                return true;
            }
        }

        return false;
    }

    // contains letter that repeats with single letter between
    private static bool PartB2(string s)
    {
        for (var i = 0; i < s.Length - 2; i++)
        {
            if (s[i] == s[i + 2])
            {
                return true;
            }
        }

        return false;
    }
}
