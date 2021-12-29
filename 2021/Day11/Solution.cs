namespace AdventOfCode._2021.Day11;

[ProblemName("Dumbo Octopus")]      
internal class Solution : ISolver
{
    private readonly int[,] _jelly = new int[12, 12];
    private int _flashes = 0;

    public object PartOne(string input)
    {
        var lines = input.Lines();

        for(var i = 0; i < 12; i++)
        for(var j = 0; j < 12; j++)
        {
            if (i is 0 or 11 || j is 0 or 11)
            {
                _jelly[i, j] = -2;
            }
            else
            {
                _jelly[i, j] = lines[i - 1][j - 1] - 48;
            }
        }

        for (var step = 0; step < 100; step++)
        {
            for (var i = 1; i < 11; i++)
            for (var j = 1; j < 11; j++)
            {
                _jelly[i, j]++;
            }

            for (var i = 1; i < 11; i++)
            for (var j = 1; j < 11; j++)
            {
                if (_jelly[i, j] > 9)
                {
                    Flash(i, j);
                }
            }

            for (var i = 1; i < 11; i++)
            for (var j = 1; j < 11; j++)
            {
                if (_jelly[i, j] < 0)
                {
                    _jelly[i, j] = 0;
                }
            }
        }

        return _flashes;
    }

    public object PartTwo(string input)
    {
        var lines = input.Lines();

        for (var i = 0; i < 12; i++)
        for (var j = 0; j < 12; j++)
        {
            if (i is 0 or 11 || j is 0 or 11)
            {
                _jelly[i, j] = -2;
            }
            else
            {
                _jelly[i, j] = lines[i - 1][j - 1] - 48;
            }
        }

        var step = 0;
        while(true)
        {
            step++;
            _flashes = 0;

            for (var i = 1; i < 11; i++)
            for (var j = 1; j < 11; j++)
            {
                _jelly[i, j]++;
            }

            for (var i = 1; i < 11; i++)
            for (var j = 1; j < 11; j++)
            {
                if (_jelly[i, j] > 9)
                {
                    Flash(i, j);
                }
            }

            if (_flashes == 100)
            {
                return step;
            }

            for (var i = 1; i < 11; i++)
            for (var j = 1; j < 11; j++)
            {
                if (_jelly[i, j] < 0)
                {
                    _jelly[i, j] = 0;
                }
            }
        }
    }

    private void Flash(int row, int col)
    {
        _jelly[row, col] = -1;
        _flashes++;

        for (var i = row - 1; i <= row + 1; i++)
        for (var j = col - 1; j <= col + 1; j++)
        {
            switch (_jelly[i, j])
            {
                case >= 9:
                    Flash(i, j);
                    break;
                case >= 0:
                    _jelly[i, j]++;
                    break;
            }
        }
    }

    private void print()
    {
        for (var i = 0; i < 12; i++)
        {
            for (var j = 0; j < 12; j++)
            {
                if (_jelly[i, j] < 0) Console.Write("*");
                else Console.Write(_jelly[i, j]);
            }

            Console.WriteLine();
        }
    }
}
