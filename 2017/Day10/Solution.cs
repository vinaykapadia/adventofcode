using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2017.Day10;

[ProblemName("Knot Hash")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        // Part 1
        var lengths = input.Split(',').Select(int.Parse);
        int[] values = new int[256];
        for (int i = 0; i < 256; i++)
        {
            values[i] = i;
        }

        int skipSize = 0;
        int position = 0;

        foreach (var length in lengths)
        {
            Reverse(values, position, length);
            position += length + skipSize;
            position %= values.Length;
            skipSize++;
        }

        return values[0] * values[1];
    }

    public object PartTwo(string input)
    {
        return KnotHash(input);
    }

    private static string KnotHash(string input)
    {
        int skipSize = 0;
        int position = 0;
        int[] values = new int[256];

        for (int i = 0; i < 256; i++)
        {
            values[i] = i;
        }

        // Run cycles.
        for (int i = 0; i < 64; i++)
        {
            foreach (var length in GetLengths(input))
            {
                Reverse(values, position, length);
                position += length + skipSize;
                position %= values.Length;
                skipSize++;
            }
        }

        // Compute dense hash.
        int[] denseHash = new int[16];
        int index = 0;
        for (int i = 0; i < values.Length; i += 16)
        {
            int value = 0;
            for (int j = 0; j < 16; j++)
            {
                value ^= values[i + j];
            }

            denseHash[index] = value;
            index++;
        }

        return denseHash.Aggregate("", (current, item) => current + Convert.ToString(item, 16));
    }

    private static IEnumerable<int> GetLengths(string input)
    {
        foreach (var c in input)
        {
            yield return c;
        }

        yield return 17;
        yield return 31;
        yield return 73;
        yield return 47;
        yield return 23;
    }

    private static void Reverse(int[] values, int start, int length)
    {
        Stack<int> stack = new Stack<int>();
        for (int i = 0; i < length; i++)
        {
            int index = (start + i) % values.Length;
            stack.Push(values[index]);
        }

        for (int i = 0; i < length; i++)
        {
            int index = (start + i) % values.Length;
            values[index] = stack.Pop();
        }
    }
}
