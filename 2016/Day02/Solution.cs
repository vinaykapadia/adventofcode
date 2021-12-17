using System.Text;

namespace AdventOfCode._2016.Day02;

[ProblemName("Bathroom Security")]      
internal class Solution : Solver
{

    public object PartOne(string input)
    {
        char[,] keypad = { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
        var sb = new StringBuilder();
        int row = 1, col = 1;

        foreach (var line in input.Lines())
        {
            foreach (var dir in line)
            {
                switch (dir)
                {
                    case 'U':
                        row--;
                        break;
                    case 'D':
                        row++;
                        break;
                    case 'L':
                        col--;
                        break;
                    case 'R':
                        col++;
                        break;
                }

                if (col < 0) col = 0;
                if (col > 2) col = 2;
                if (row < 0) row = 0;
                if (row > 2) row = 2;
            }

            sb.Append(keypad[row, col]);
        }

        return sb.ToString();
    }

    public object PartTwo(string input)
    {
        var keypad = new[,] { { 'X', 'X', '1', 'X', 'X' }, { 'X', '2', '3', '4', 'X' }, { '5', '6', '7', '8', '9' }, { 'X', 'A', 'B', 'C', 'X' }, { 'X', 'X', 'D', 'X', 'X' } };
        var sb = new StringBuilder();
        var row = 2; var col = 0;

        foreach (var line in input.Lines())
        {
            foreach (var dir in line)
            {
                switch (dir)
                {
                    case 'U':
                        if (row > 0 && keypad[row - 1, col] != 'X') row--;
                        break;
                    case 'D':
                        if (row < 4 && keypad[row + 1, col] != 'X') row++;
                        break;
                    case 'L':
                        if (col > 0 && keypad[row, col - 1] != 'X') col--;
                        break;
                    case 'R':
                        if (col < 4 && keypad[row, col + 1] != 'X') col++;
                        break;
                }
            }

            sb.Append(keypad[row, col]);
        }

        return sb.ToString();
    }
}
