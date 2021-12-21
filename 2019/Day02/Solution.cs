using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2019.Day02;

[ProblemName("1202 Program Alarm")]      
internal class Solution : ISolver
{
    private static readonly IntcodeComputer Computer = new IntcodeComputer();

    public object PartOne(string input)
    {
        // Part 1

        var program = input.Split(',').Select(long.Parse).ToArray();

        program[1] = 12;
        program[2] = 2;

        program = Computer.Process(program);

        return program[0];
    }

    public object PartTwo(string input)
    {
        var progList = input.Split(',').Select(long.Parse).ToArray();

        for (int i = 0; i < 100; i++)
        {
            for (int j = 0; j < 100; j++)
            {
                var program = progList;
                program[1] = i;
                program[2] = j;

                program = Computer.Process(program);

                if (program[0] == 19690720)
                    return 100 * i + j;
            }
        }

        return 0;
    }
}
