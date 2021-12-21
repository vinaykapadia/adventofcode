using System;

namespace AdventOfCode._2017.Day03;

[ProblemName("Spiral Memory")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        int num = int.Parse(input);
        var square = (int)Math.Ceiling(Math.Sqrt(num));
        if (square % 2 == 0) square++;
        int high = square * square;
        square -= 2;
        int low = square * square + 1;
        int dist1 = (high - low + 1) / 8;
        int width = (high - low + 1) / 4;

        while (num > low + width)
        {
            low += width;
        }

        int target = low - 1 + dist1;
        int dist2 = Math.Abs(target - num);

        return dist1 + dist2;
    }

    public object PartTwo(string input)
    {
        return 0;
    }
}
