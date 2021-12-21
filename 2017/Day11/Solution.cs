using System;
using AdventOfCode.Common;

namespace AdventOfCode._2017.Day11;

[ProblemName("Hex Ed")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        var directions = input.Split(',');

        int x = 0, y = 0;
        int maxSteps = 0;

        foreach (var dir in directions)
        {
            switch (dir)
            {
                case "n":
                    y--;
                    break;
                case "s":
                    y++;
                    break;
                case "ne":
                    x++;
                    y -= x % 2 == 0 ? 1 : 0;
                    break;
                case "se":
                    x++;
                    y += x % 2 == 0 ? 0 : 1;
                    break;
                case "nw":
                    x--;
                    y -= x % 2 == 0 ? 1 : 0;
                    break;
                case "sw":
                    x--;
                    y += x % 2 == 0 ? 0 : 1;
                    break;
                default: throw new InvalidOperationException();
            }

            int currentSteps = CalcSteps(x, y);
            if (currentSteps > maxSteps) maxSteps = currentSteps;
        }

        int steps = CalcSteps(x, y);
        Utilities.PartBAnswer = maxSteps;
        return steps;
    }

    public object PartTwo(string input)
    {
        return Utilities.PartBAnswer;
    }

    private static int CalcSteps(int x, int y)
    {
        int steps = 0;
        while (x != 0 && y != 0)
        {
            if (x > 0)
            {
                if (y > 0)
                {
                    x--;
                    y -= x % 2 == 0 ? 1 : 0;
                }
                else
                {
                    x--;
                    y += x % 2 == 0 ? 0 : 1;
                }
            }
            else
            {
                if (y > 0)
                {
                    x++;
                    y -= x % 2 == 0 ? 1 : 0;
                }
                else
                {
                    x++;
                    y += x % 2 == 0 ? 0 : 1;
                }
            }
            steps++;
        }

        steps += y + x;
        return steps;
    }
}
