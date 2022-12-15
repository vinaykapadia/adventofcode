using System.Text;

namespace AdventOfCode._2022.Day10;

[ProblemName("Cathode-Ray Tube")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        var x = 1;
        var cycle = 0;
        var sum = 0;

        foreach (var line in input.Lines())
        {
            cycle++;

            if ((cycle - 20) % 40 == 0)
            {
                sum += cycle * x;
            }

            if (line[0] == 'a')
            {
                cycle++;

                if ((cycle - 20) % 40 == 0)
                {
                    sum += cycle * x;
                }

                var num = int.Parse(line[5..]);
                x += num;
            }
        }

        return sum;
    }

    public object PartTwo(string input)
    {
        var x = 1;
        var cycle = 0;

        var display = new char[6][];
        for (var i = 0; i < 6; i++)
        {
            display[i] = new char[40];
        }

        foreach (var line in input.Lines())
        {
            cycle++;

            var row = (cycle - 1) / 40;
            var col = (cycle - 1) % 40;
            display[row][col] = col == x - 1 || col == x || col == x + 1 ? '#' : ' ';
            
            if (line[0] == 'a')
            {
                cycle++;

                row = (cycle - 1) / 40;
                col = (cycle - 1) % 40;
                display[row][col] = col == x - 1 || col == x || col == x + 1 ? '#' : ' ';

                var num = int.Parse(line[5..]);
                x += num;
            }
        }

        StringBuilder sb = new();
        for (var i = 0; i < 6; i++)
        {
            sb.Append(display[i]);
            sb.AppendLine();
        }

        return sb.ToString().Ocr();
    }
}
