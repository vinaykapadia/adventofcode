using System;
using System.Collections.Generic;

namespace AdventOfCode._2017.Day16;

[ProblemName("Permutation Promenade")]      
internal class Solution : ISolver
{
    Dictionary<string, string> seen = new Dictionary<string, string>();
    private static char[] programs = new char[16];

    public object PartOne(string input)
    {
        int i;
        for (i = 0; i < 16; i++)
        {
            programs[i] = (char)('a' + i);
        }

        string start = new string(programs);
        Dance(input);
        var final = new string(programs);
        seen.Add(start, final);

        return final;
    }

    public object PartTwo(string input)
    {
        var final = new string(programs);

        for (int i = 1; i < 1000000000; i++)
        {
            var start = final;
            if (seen.ContainsKey(start))
            {
                final = seen[start];
                programs = final.ToCharArray();
            }
            else
            {
                Dance(input);
                final = new string(programs);
                seen.Add(start, final);
            }
        }

        return final;
    }

    private static void Spin(int count)
    {
        for (int i = 0; i < count; i++)
        {
            char c = programs[^1];
            for (int j = programs.Length - 1; j > 0; j--)
            {
                programs[j] = programs[j - 1];
            }

            programs[0] = c;
        }
    }

    private static void Dance(string steps)
    {
        foreach (var instruction in steps.Split(','))
        {
            string inst = instruction[1..];
            switch (instruction[0])
            {
                case 's':
                    Spin(int.Parse(inst));
                    break;
                case 'x':
                    Exchange(inst);
                    break;
                case 'p':
                    Partner(inst);
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }
    }

    private static void Exchange(string inst)
    {
        int slash = inst.IndexOf('/');
        string first = inst[..slash];
        string last = inst[(slash + 1)..];
        Swap(int.Parse(first), int.Parse(last));
    }

    private static void Partner(string inst)
    {
        int i=0, j=0;
        while (programs[i] != inst[0]) i++;
        while (programs[j] != inst[2]) j++;
        Swap(i, j);
    }

    private static void Swap(int a, int b)
    {
        (programs[a], programs[b]) = (programs[b], programs[a]);
    }
}
