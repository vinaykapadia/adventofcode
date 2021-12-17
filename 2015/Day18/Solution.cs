using System;

namespace AdventOfCode._2015.Day18;

[ProblemName("Like a GIF For Your Yard")]      
internal class Solution : Solver {
private static int size = 0;

    public object PartOne(string input)
    {
        int steps = 100;
        size = input.Lines().Length;

        int[,] grid = new int[size + 2, size + 2];

        int x = 1;
        foreach (var line in input.Lines())
        {
            int y = 1;
            foreach (var c in line)
            {
                if (c == '#') grid[x, y] = 1;
                else if (c == '.') grid[x, y] = 0;
                else throw new Exception();
                y++;
            }
            x++;
        }
        
        for (int step = 0; step < steps; step++)
        {
            int[,] nextGrid = new int[size + 2, size + 2];
            for (int i = 1; i <= size; i++)
            {
                for (int j = 1; j <= size; j++)
                {
                    int n = CountNeighbors(grid, i, j);
                    if (n == 3 || (n == 2 && grid[i, j] == 1))
                    {
                        nextGrid[i, j] = 1;
                    }
                }
            }

            grid = nextGrid;
        }

        int count = 0;
        for (int i = 1; i <= size; i++)
        {
            for (int j = 1; j <= size; j++)
            {
                count += grid[i, j];
            }
        }

        return count;
    }

    public object PartTwo(string input) {
        int steps = 100;
        size = input.Lines().Length;

        int[,] grid = new int[size + 2, size + 2];

        int x = 1;
        foreach (var line in input.Lines())
        {
            int y = 1;
            foreach (var c in line)
            {
                if (c == '#') grid[x, y] = 1;
                else if (c == '.') grid[x, y] = 0;
                else throw new Exception();
                y++;
            }
            x++;
        }

        for (int step = 0; step < steps; step++)
        {
            int[,] nextGrid = new int[size + 2, size + 2];
            for (int i = 1; i <= size; i++)
            {
                for (int j = 1; j <= size; j++)
                {
                    // This if statement is only for part B
                    if ((i > 1 && i < size) || (j > 1 && j < size))
                    {
                        int n = CountNeighbors(grid, i, j);
                        if (n == 3 || (n == 2 && grid[i, j] == 1))
                        {
                            nextGrid[i, j] = 1;
                        }
                    }
                    else
                    {
                        nextGrid[i, j] = 1;
                    }
                }
            }

            grid = nextGrid;
        }

        int count = 0;
        for (int i = 1; i <= size; i++)
        {
            for (int j = 1; j <= size; j++)
            {
                count += grid[i, j];
            }
        }

        return count;
    }

    private static int CountNeighbors(int[,] grid, int i, int j)
    {
        int sum = -grid[i, j];
        for (int x = i - 1; x <= i + 1; x++)
        {
            for (int y = j - 1; y <= j + 1; y++)
            {
                sum += grid[x, y];
            }
        }
        return sum;
    }
}
