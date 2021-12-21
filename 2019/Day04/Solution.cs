using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using AdventOfCode.Lib;

namespace AdventOfCode._2019.Day04;

[ProblemName("Secure Container")]      
internal class Solution : ISolver
{
    // Input typed in.

    public object PartOne(string input)
    {
        int num1 = 0;
        int num2 = 0;
        var x = PasswordWorks2(123444);
        for (int i = 234208; i <= 765869; i++)
        {
            if (PasswordWorks1(i)) num1++;
            if (PasswordWorks2(i)) num2++;
        }

        Utilities.PartBAnswer = num2;
        return num1;
    }

    public object PartTwo(string input)
    {
        return Utilities.PartBAnswer;
    }

    private static bool PasswordWorks1(int pw)
    {
        var digits = GetDigits(pw);
        int prev = -1;
        bool dupe = false;

        var hashset = new HashSet<int>();
        foreach (var digit in digits)
        {
            if (digit < prev) return false;
            prev = digit;
            if (!hashset.Add(digit))
            {
                dupe = true;
            }
        }

        return dupe;
    }

    private static bool PasswordWorks2(int pw)
    {
        var digits = GetDigits(pw).ToArray();
        int prev = -1;
        var counts = new AutoAddingDictionary<int, int>();

        foreach (var digit in digits)
        {
            if (digit < prev) return false;
            prev = digit;

            counts[digit]++;
        }

        return counts.Any(x => x.Value == 2);
    }

    private static IEnumerable<int> GetDigits(int source)
    {
        int individualFactor = 0;
        int tennerFactor = Convert.ToInt32(Math.Pow(10, source.ToString().Length));
        do
        {
            source -= tennerFactor * individualFactor;
            tennerFactor /= 10;
            individualFactor = source / tennerFactor;

            yield return individualFactor;
        } while (tennerFactor > 1);
    }
}
