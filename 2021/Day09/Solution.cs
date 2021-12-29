using System.Text.RegularExpressions;

namespace AdventOfCode._2021.Day09;

[ProblemName("Smoke Basin")]      
internal class Solution : ISolver
{
    public object PartOne(string input)
    {
        var nums = Regex.Matches(input, "\\d").Select(x => int.Parse(x.Value)).ToArray();
        var map = new int[102, 102];

        for (var i = 0; i < 102; i++)
        for(var j = 0; j < 102; j++)
        {
            if (i is 0 or 101 || j is 0 or 101) map[i, j] = 10;
            else map[i, j] = nums[(i - 1) * 100 + (j - 1)];
        }

        var sum = 0;
        for (var i = 1; i < 101; i++)
        for (var j = 1; j < 101; j++)
        {
            var x = map[i, j];
            if (x < map[i - 1, j] &&
                x < map[i + 1, j] &&
                x < map[i, j - 1] &&
                x < map[i, j + 1])
                sum += x + 1;
        }

        return sum;
    }

    public object PartTwo(string input)
    {
        var nums = Regex.Matches(input, "\\d").Select(x => int.Parse(x.Value)).ToArray();
        var map = new bool[102, 102];

        for (var i = 0; i < 102; i++)
        for (var j = 0; j < 102; j++)
        {
            if (i is 0 or 101 || j is 0 or 101) map[i, j] = true;
            else
            {
                var num = nums[(i - 1) * 100 + (j - 1)];
                map[i, j] = num == 9;
            }
        }

        var sizes = new List<int>();

        for (var i = 1; i < 101; i++)
        for (var j = 1; j < 101; j++)
        {
            if (map[i, j]) continue;
            sizes.Add(FillBasin(map, i, j));
        }

        return sizes.OrderByDescending(x => x).Take(3).Aggregate((a, y) => a * y);
    }

    private static int FillBasin(bool[,] map, int row, int col)
    {
        if (map[row, col]) return 0;
        map[row, col] = true;
        return 1
               + FillBasin(map, row - 1, col)
               + FillBasin(map, row + 1, col)
               + FillBasin(map, row, col - 1)
               + FillBasin(map, row, col + 1);
    }
}
