using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2017.Day14;

[ProblemName("Disk Defragmentation")]      
internal class Solution : ISolver
{
    private static readonly char[,] Field = new char[128, 128];

    public object PartOne(string input)
    {
        int total = 0;

        for (int i = 0; i < 128; i++)
        {
            string hash = KnotHash(input + "-" + i);
            for (int j = 0; j < 32; j++)
            {
                string bits = GetBitCount(hash[j]);
                total += bits.Count(x => x == '1');
                for (int k = 0; k < 4; k++)
                    Field[i, j * 4 + k] = bits[k];
            }
        }

        return total;
    }

    public object PartTwo(string input)
    {
        int fieldCount = 0;
        
        for (int i = 0; i < 128; i++)
        {
            for (int j = 0; j < 128; j++)
            {
                if (Field[i, j] == '1')
                {
                    fieldCount++;
                    ClearField(i, j);
                }
            }
        }

        return fieldCount;
    }

    private static void ClearField(int x, int y)
    {
        Field[x, y] = '0';

        if (x != 0 && Field[x - 1, y] == '1')
            ClearField(x - 1, y);

        if (x != 127 && Field[x + 1, y] == '1')
            ClearField(x + 1, y);

        if (y != 0 && Field[x, y - 1] == '1')
            ClearField(x, y - 1);

        if (y != 127 && Field[x, y + 1] == '1')
            ClearField(x, y + 1);
    }

    private static string GetBitCount(char ch)
    {
        switch (ch)
        {
            case '0': return "0000";
            case '1': return "0001";
            case '2': return "0010";
            case '3': return "0011";
            case '4': return "0100";
            case '5': return "0101";
            case '6': return "0110";
            case '7': return "0111";
            case '8': return "1000";
            case '9': return "1001";
            case 'a': return "1010";
            case 'b': return "1011";
            case 'c': return "1100";
            case 'd': return "1101";
            case 'e': return "1110";
            case 'f': return "1111";
            default: throw new InvalidOperationException();
        }
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

        return denseHash.Aggregate("", (current, item) => current + item.ToString("x2"));
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
