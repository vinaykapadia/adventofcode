using Newtonsoft.Json.Linq;

namespace AdventOfCode._2022.Day09;

[ProblemName("Rope Bridge")]      
internal class Solution : ISolver
{
    private const int BoardSize = 600;

    public object PartOne(string input)
    {
        int headX = 500, headY = 500, tailX = 500, tailY = 500;
        var board = new bool[1000, 1000];
        board[500, 500] = true;

        foreach (var line in input.Lines())
        {
            var steps = int.Parse(line[2..]);
            for (var i = 0; i < steps; i++)
            {
                switch (line[0])
                {
                    case 'L':
                        headX--;
                        break;
                    case 'R':
                        headX++;
                        break;
                    case 'U':
                        headY--;
                        break;
                    case 'D':
                        headY++;
                        break;
                }

                if (headX - tailX == 2)
                {
                    tailX++;
                    tailY = headY;
                }
                else if (headX - tailX == -2)
                {
                    tailX--;
                    tailY = headY;
                }
                else if (headY - tailY == 2)
                {
                    tailY++;
                    tailX = headX;
                }
                else if (headY - tailY == -2)
                {
                    tailY--;
                    tailX = headX;
                }

                board[tailX, tailY] = true;
            }
        }

        var count = 0;
        for (var i = 0; i < 1000; i++)
        for (var j = 0; j < 1000; j++)
            if (board[i, j])
                count++;

        return count;
    }
    
    public object PartTwo(string input)
    {
        var knotX = new int[10];
        var knotY = new int[10];
        for (var i = 0; i < 10; i++)
        {
            knotX[i] = BoardSize / 2;
            knotY[i] = BoardSize / 2;
        }
        var board = new bool[BoardSize, BoardSize];
        board[BoardSize / 2, BoardSize / 2] = true;

        foreach (var line in input.Lines())
        {
            var steps = int.Parse(line[2..]);
            for (var i = 0; i < steps; i++)
            {
                switch (line[0])
                {
                    case 'L':
                        knotX[0]--;
                        break;
                    case 'R':
                        knotX[0]++;
                        break;
                    case 'U':
                        knotY[0]--;
                        break;
                    case 'D':
                        knotY[0]++;
                        break;
                }

                for (var j = 1; j < 10; j++)
                {
                    if (knotX[j - 1] - knotX[j] == 2 && knotY[j - 1] - knotY[j] == 2)
                    {
                        knotX[j]++;
                        knotY[j]++;
                    }
                    else if (knotX[j - 1] - knotX[j] == 2 && knotY[j - 1] - knotY[j] == -2)
                    {
                        knotX[j]++;
                        knotY[j]--;
                    }
                    else if (knotX[j - 1] - knotX[j] == -2 && knotY[j - 1] - knotY[j] == 2)
                    {
                        knotX[j]--;
                        knotY[j]++;
                    }
                    else if (knotX[j - 1] - knotX[j] == -2 && knotY[j - 1] - knotY[j] == -2)
                    {
                        knotX[j]--;
                        knotY[j]--;
                    }
                    else if (knotX[j - 1] - knotX[j] == 2)
                    {
                        knotX[j]++;
                        knotY[j] = knotY[j-1];
                    }
                    else if (knotX[j - 1] - knotX[j] == -2)
                    {
                        knotX[j]--;
                        knotY[j] = knotY[j - 1];
                    }
                    else if (knotY[j - 1] - knotY[j] == 2)
                    {
                        knotY[j]++;
                        knotX[j] = knotX[j - 1];
                    }
                    else if (knotY[j - 1] - knotY[j] == -2)
                    {
                        knotY[j]--;
                        knotX[j] = knotX[j - 1];
                    }
                }

                board[knotX[9], knotY[9]] = true;
            }
        }

        var count = 0;
        for (var i = 0; i < BoardSize; i++)
        for (var j = 0; j < BoardSize; j++)
            if (board[i, j])
                count++;
        
        return count;
    }

    private void PrintBoard(IReadOnlyList<int> knotX, IReadOnlyList<int> knotY)
    {
        Console.WriteLine();
        for (var i = 0; i < BoardSize; i++)
        {
            for (var j = 0; j < BoardSize; j++)
            {
                bool f = false;
                for (int z = 0; z < 10; z++)
                {
                    if (!f && i == BoardSize / 2 && j == BoardSize / 2)
                    {
                        f = true;
                        Console.Write("S");
                    }
                    if (!f && j == knotX[z] && i == knotY[z])
                    {
                        f = true;
                        Console.Write(z);
                    }
                }

                if (!f)
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}