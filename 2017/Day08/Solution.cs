using System;
using System.Linq;

namespace AdventOfCode._2017.Day08;

[ProblemName("I Heard You Like Registers")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        AutoAddingDictionary<string, int> registers = new AutoAddingDictionary<string, int>();
        int maxEver = 0;
        
        foreach (var line in input.Lines())
        {
            string[] command = line.Split(' ');
            int leftSide = registers[command[4]];
            string comparison = command[5];
            int rightSide = int.Parse(command[6]);
            if (Compare(leftSide, comparison, rightSide))
            {
                int change = int.Parse(command[2]);
                if (command[1] == "dec") change = -change;
                registers[command[0]] += change;
                int maxCurrent = registers.Max(x => x.Value);
                if (maxCurrent > maxEver) maxEver = maxCurrent;
            }
        }

        Utilities.PartBAnswer = maxEver;
        int max = registers.Max(x => x.Value);
        return max;
    }

    public object PartTwo(string input)
    {
        return Utilities.PartBAnswer;
    }

    private static bool Compare(int left, string op, int right) =>
        op switch
        {
            "<" => left < right,
            ">" => left > right,
            "<=" => left <= right,
            ">=" => left >= right,
            "==" => left == right,
            "!=" => left != right,
            _ => throw new Exception()
        };
}
