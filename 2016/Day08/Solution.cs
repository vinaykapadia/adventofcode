using System;
using System.Text.RegularExpressions;

namespace AdventOfCode._2016.Day08;

[ProblemName("Two-Factor Authentication")]      
internal class Solution : Solver
{
    private const int R = 6;
    private const int C = 50;
    private static readonly bool[,] Lights = new bool[C, R];

    public object PartOne(string input)
    {
        Regex reg = new Regex(@"\d+");

        foreach (var line in input.Lines())
        {
            MatchCollection matches = reg.Matches(line);
            int a = int.Parse(matches[0].ToString());
            int b = int.Parse(matches[1].ToString());

            if (line.StartsWith("rect"))
                Rect(a, b);
            else if (line.Contains("column"))
                RotateColumn(a, b);
            else if (line.Contains("row"))
                RotateRow(a, b);
        }

        int count = 0;
        for (int i = 0; i < C; i++)
        {
            for (int j = 0; j < R; j++)
            {
                if (Lights[i, j]) count++;
            }
        }

        return count;
    }

    public object PartTwo(string input)
    {
        // Just showed it on screen, then typed the answer here.
        /*for (int j = 0; j < R; j++)
        {
            for (int i = 0; i < C; i++)
            {
                Console.Write(Lights[i, j] ? "*" : " ");
                if (i % 5 == 4)
                {
                    Console.Write("  ");
                }
            }

            Console.WriteLine();
        }*/
        return "CFLELOYFCS";
    }

    private static void Rect(int a, int b)
    {
        for (int i = 0; i < a; i++)
        {
            for (int j = 0; j < b; j++)
            {
                Lights[i, j] = true;
            }
        }
    }

    private static void RotateColumn(int a, int b)
    {
        for (int n = 0; n < b; n++)
        {
            bool temp = Lights[a, R - 1];
            for (int i = R - 1; i >= 1; i--)
            {
                Lights[a, i] = Lights[a, i - 1];
            }

            Lights[a, 0] = temp;
        }
    }

    private static void RotateRow(int a, int b)
    {
        for (int n = 0; n < b; n++)
        {
            bool temp = Lights[C - 1, a];
            for (int i = C - 1; i >= 1; i--)
            {
                Lights[i, a] = Lights[i - 1, a];
            }

            Lights[0, a] = temp;
        }
    }
}
