using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using adventofcode.Lib;

namespace AdventOfCode._2017.Day12;

[ProblemName("Digital Plumber")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        List<List<string>> groups = new List<List<string>>();
        List<string> programs;
        AutoAddingDictionary<string, List<string>> map = new AutoAddingDictionary<string, List<string>>();

        foreach (var line in input.Lines())
        {
            string prog = line[..(line.IndexOf('<') - 1)];
            map[prog] = new List<string>();
            foreach (var pipe in line[(line.IndexOf('>') + 2)..].Split(',').Select(x => x.Trim()))
            {
                if (pipe != prog)
                {
                    map[prog].Add(pipe);
                }
            }
        }

        void GetPipes(string key)
        {
            if (!programs.Contains(key)) programs.Add(key);
            foreach (string prog in map[key].Where(prog => !programs.Contains(prog)))
            {
                GetPipes(prog);
            }
        }

        for (int i = 0; i < map.Count; i++)
        {
            string key = i.ToString();
            if (!groups.Any(x => x.Contains(key)))
            {
                programs = new List<string>();
                GetPipes(key);
                groups.Add(programs);
            }
        }

        Utilities.PartBAnswer = groups.Count;
        return groups.First(x => x.Contains("0")).Count;
    }

    public object PartTwo(string input)
    {
        return Utilities.PartBAnswer;
    }
}
