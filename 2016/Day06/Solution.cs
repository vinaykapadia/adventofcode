using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode._2016.Day06;

[ProblemName("Signals and Noise")]      
internal class Solution : Solver
{
    public static string PartBAnswer { get; set; }

    public object PartOne(string input)
    {
        var lines = input.Lines();
        var count = lines[0].Length;

        Dictionary<char, int>[] letters = new Dictionary<char, int>[lines[0].Length];
        for (int i = 0; i < count; i++)
        {
            letters[i] = new Dictionary<char, int>();
        }

        foreach (var line in lines)
        {
            for (int i = 0; i < count; i++)
            {
                if (!letters[i].ContainsKey(line[i])) letters[i].Add(line[i], 0);
                letters[i][line[i]]++;
            }
        }

        PartBAnswer = letters.Aggregate("", (current, letter) => current + (letter.First(x => x.Value == letter.Min(y => y.Value)).Key)); 
        return letters.Aggregate("", (current, letter) => current + (letter.First(x => x.Value == letter.Max(y => y.Value)).Key));
    }

    public object PartTwo(string input)
    {
        return PartBAnswer;
    }
}
