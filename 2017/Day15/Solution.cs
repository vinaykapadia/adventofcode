using System;

namespace AdventOfCode._2017.Day15;

[ProblemName("Dueling Generators")]      
internal class Solution : ISolver
{
    // values from input are just typed in

    public object PartOne(string input)
    {
        long a = 703;
        long b = 516;
        int total = 0;

        for (int i = 0; i < 40000000; i++)
        {
            a = Generate(a, 16807);
            b = Generate(b, 48271);
            string ab = Convert.ToString(a, 2).PadLeft(16, '0');
            ab = ab[^16..];
            string bb = Convert.ToString(b, 2).PadLeft(16, '0'); ;
            bb = bb[^16..];
            if (ab == bb) total++;
        }

        return total;
    }

    public object PartTwo(string input)
    {
        long a = 703;
        long b = 516;
        var total = 0;

        for (int i = 0; i < 5000000; i++)
        {
            a = Generate(a, 16807);
            while (a % 4 != 0) a = Generate(a, 16807);
            b = Generate(b, 48271);
            while (b % 8 != 0) b = Generate(b, 48271);
            string ab = Convert.ToString(a, 2).PadLeft(16, '0');
            ab = ab.Substring(ab.Length - 16);
            string bb = Convert.ToString(b, 2).PadLeft(16, '0'); ;
            bb = bb.Substring(bb.Length - 16);
            if (ab == bb) total++;
        }

        return total;
    }

    private static long Generate(long prev, long factor)
    {
        return prev * factor % 2147483647;
    }
}
