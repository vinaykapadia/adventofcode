using System;
using System.Collections.Generic;
using AdventOfCode.Common;

namespace AdventOfCode._2017.Day17;

[ProblemName("Spinlock")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        List<int> buffer = new List<int> { 0 };
        int pos = 0;
        int steps = 301;

        int i;
        for (i = 1; i <= 2017; i++)
        {
            pos += steps;
            pos %= i;
            pos++;
            buffer.Insert(pos, i);
        }

        int index = buffer.IndexOf(2017);
        int value = buffer[index + 1];

        int a = value;

        for (; i <= 50000000; i++)
        {
            pos += steps;
            pos %= i;
            pos++;
            if (pos == 1) value = i;
        }

        Utilities.PartBAnswer = value;
        return a;
    }

    public object PartTwo(string input)
    {
        return Utilities.PartBAnswer;
    }
}
