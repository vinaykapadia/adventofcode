namespace AdventOfCode._2018.Day11;

[ProblemName("Chronal Charge")]      
internal class Solution : ISolver
{
    // I'm just entering the input values here.
    private const int Serial = 6303;

    public object PartOne(string input)
    {
        var (highX, highY, _) = GetFuel(GetGrid(), 3);
        return $"{highX},{highY}";
    }

    private static int[,] GetGrid()
    {
        var grid = new int[301, 301];

        for (var x = 1; x <= 300; x++)
        {
            for (var y = 1; y <= 300; y++)
            {
                var p = ((x + 10) * y + Serial) * (x + 10) / 100 % 10 - 5;
                grid[x, y] = p;
            }
        }

        return grid;
    }

    private static (int highX, int highY, int highPower) GetFuel(int[,] grid, int size)
    {
        var highX = 1;
        var highY = 1;
        var highPower = int.MinValue;

        for (var x = 1; x <= 301 - size; x++)
        {
            for (var y = 1; y <= 301 - size; y++)
            {
                var power = 0;
                for (var zx = 0; zx < size; zx++)
                for (var zy = 0; zy < size; zy++)
                {
                    power += grid[x + zx, y + zy];
                }

                if (power > highPower)
                {
                    highPower = power;
                    highX = x;
                    highY = y;
                }
            }
        }

        return (highX, highY, highPower);
    }

    public object PartTwo(string input)
    {
        var highX = 0;
        var highY = 0;
        var highPower = int.MinValue;
        var highSize = 0;

        for (var i = 1; i <= 300; i++)
        {
            var (x, y, power) = GetFuel(GetGrid(), i);
            if (power > highPower)
            {
                highX = x;
                highY = y;
                highPower = power;
                highSize = i;
            }
        }

        return $"{highX},{highY},{highSize}";
    }
}
