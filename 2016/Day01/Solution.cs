using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2016.Day01;

[ProblemName("No Time for a Taxicab")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        var direction = 0; //0 = N, 1 = E, 2 = S, 3 = W
        int row = 0, col = 0;

        foreach (var ins in input.Replace(" ", "").Split(','))
        {
            var dir = ins[0];
            var blocks = int.Parse(ins[1..]);
            direction += dir == 'R' ? 1 : -1;
            direction = (direction + 4) % 4;
            switch (direction)
            {
                case 0:
                    row += blocks;
                    break;
                case 1:
                    col += blocks;
                    break;
                case 2:
                    row -= blocks;
                    break;
                case 3:
                    col -= blocks;
                    break;
            }
        }

        return Math.Abs(row) + Math.Abs(col);
    }

    public object PartTwo(string input)
    {
        var direction = 0; //0 = N, 1 = E, 2 = S, 3 = W
        var row = 0; var col = 0;
        var visited = new List<Tuple<int, int>> { new (0, 0) };

        foreach (var ins in input.Replace(" ", "").Split(','))
        {
            var dir = ins[0];
            var blocks = int.Parse(ins[1..]);
            direction += dir == 'R' ? 1 : -1;
            direction = (direction + 4) % 4;
            for (var i = 0; i < blocks; i++)
            {
                switch (direction)
                {
                    case 0:
                        row += 1;
                        break;
                    case 1:
                        col += 1;
                        break;
                    case 2:
                        row -= 1;
                        break;
                    case 3:
                        col -= 1;
                        break;
                }

                if (visited.Any(x => x.Item1 == row && x.Item2 == col))
                {
                    return Math.Abs(row) + Math.Abs(col);
                }

                visited.Add(new Tuple<int, int>(row, col));
            }
        }

        return null;
    }
}
