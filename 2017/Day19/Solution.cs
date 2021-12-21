using AdventOfCode.Common;

namespace AdventOfCode._2017.Day19;

[ProblemName("A Series of Tubes")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        var lines = input.Lines();

        int x = 0, y = 0, xDir = 0, yDir = 1;
        string output = "";
        int steps = 0;

        while (lines[y][x] != '|') x++;

        bool done = false;
        while (!done)
        {
            switch (lines[y][x])
            {
                case '|':
                case '-':
                    break;
                case ' ':
                    done = true;
                    steps--;
                    break;
                case '+':
                    ChangeDirection();
                    break;
                default:
                    output += lines[y][x];
                    break;
            }
            x += xDir;
            y += yDir;
            steps++;
        }

        Utilities.PartBAnswer = steps;
        return output;

        void ChangeDirection()
        {
            if (xDir == 0)
            {
                yDir = 0;
                if (x == 0 || lines[y][x - 1] == ' ' || lines[y][x - 1] == '|') xDir = 1;
                else xDir = -1;
            }
            else
            {
                xDir = 0;
                if (y == 0 || lines[y - 1][x] == ' ' || lines[y - 1][x] == '-') yDir = 1;
                else yDir = -1;
            }
        }
    }

    public object PartTwo(string input)
    {
        return Utilities.PartBAnswer;
    }
}
