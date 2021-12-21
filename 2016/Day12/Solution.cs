using System.Collections.Generic;
using System.Reflection;
using adventofcode.Lib;

namespace AdventOfCode._2016.Day12;

[ProblemName("Leonardo's Monorail")]      
internal class Solution : ISolver
{
    private AutoAddingDictionary<char, int> registers;
    int i;

    public object PartOne(string input)
    {
        registers = new AutoAddingDictionary<char, int>();
        Run(input.Lines());
        return registers['a'];
    }

    public object PartTwo(string input)
    {
        registers = new AutoAddingDictionary<char, int> { { 'c', 1 } };
        Run(input.Lines());
        return registers['a'];
    }

    private void Run(string[] lines)
    {
        i = 0;
        while (i < lines.Length)
        {
            var ins = lines[i].Split(' ');
            switch (ins[0])
            {
                case "cpy":
                    Copy(ins[1], ins[2][0]);
                    break;
                case "inc":
                    Bump(ins[1][0], 1);
                    break;
                case "dec":
                    Bump(ins[1][0], -1);
                    break;
                case "jnz":
                    Jump(ins[1], int.Parse(ins[2]));
                    break;
            }
        }
    }

    private void Copy(string from, char to)
    {
        i++;
        if (from == null) return;

        if (!int.TryParse(from, out var value))
        {
            value = registers[from[0]];
        }

        registers[to] = value;
    }

    private void Bump(char reg, int amount)
    {
        i++;
        registers[reg] += amount;
    }

    private void Jump(string check, int amount)
    {
        if (check == null) return;

        if (!int.TryParse(check, out var value))
        {
            value = registers[check[0]];
        }

        if (value == 0) i++;
        else i += amount;
    }
}
