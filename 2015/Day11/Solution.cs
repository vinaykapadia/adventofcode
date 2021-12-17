using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace AdventOfCode._2015.Day11;

[ProblemName("Corporate Policy")]      
internal class Solution : Solver {
    public static string PartAAnswer { get; set; }

    public object PartOne(string input) {
        var pass = input.ToCharArray();
        var searching = true;
        while (searching)
        {
            Increment(pass, 7);
            if (HasStraight(pass) && HasSet(pass))
            {
                searching = false;
            }
        }

        PartAAnswer = new string(pass);
        return PartAAnswer;
    }

    public object PartTwo(string input) {
        var pass = PartAAnswer.ToCharArray();
        var searching = true;
        while (searching)
        {
            Increment(pass, 7);
            if (HasStraight(pass) && HasSet(pass))
            {
                searching = false;
            }
        }
        
        return new string(pass);
    }

    private static bool HasSet(char[] pass)
    {
        for (int i = 0; i < 5; i++)
        {
            if (pass[i] == pass[i + 1])
            {
                for (int j = i + 2; j < 7; j++)
                {
                    if (pass[i] != pass[j] && pass[j] == pass[j + 1])
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private static bool HasStraight(char[] pass)
    {
        for (int i = 0; i < 6; i++)
        {
            if (pass[i] + 1 == pass[i + 1] && pass[i] + 2 == pass[i + 2])
            {
                return true;
            }
        }
        return false;
    }

    private static void Increment(char[] pass, int index)
    {
        if (pass[index] == 'z')
        {
            pass[index] = 'a';
            Increment(pass, index - 1);
        }
        else
        {
            pass[index]++;
            if (pass[index] == 'i' || pass[index] == 'o' || pass[index] == 'l')
            {
                pass[index]++;
            }
        }
    }
}
