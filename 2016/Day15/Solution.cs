using System.Text.RegularExpressions;

namespace AdventOfCode._2016.Day15;

[ProblemName("Timing is Everything")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        var lines = input.Lines();
        var position = new int[lines.Length];
        var max = new int[lines.Length];

        for (var i = 0; i < lines.Length; i++)
        {
            var nums = Regex.Matches(lines[i], "\\d+");
            max[i] = int.Parse(nums[1].Value);
            position[i] = (int.Parse(nums[3].Value) + 1) % max[i];
        }

        return RunMachine(max, position);
    }

    public object PartTwo(string input)
    {
        var lines = input.Lines();
        var position = new int[lines.Length + 1];
        var max = new int[lines.Length + 1];

        for (var i = 0; i < lines.Length; i++)
        {
            var nums = Regex.Matches(lines[i], "\\d+");
            max[i] = int.Parse(nums[1].Value);
            position[i] = (int.Parse(nums[3].Value) + 1) % max[i];
        }

        position[^1] = 1;
        max[^1] = 11;

        return RunMachine(max, position);
    }

    private static int RunMachine(int[] max, int[] position)
    {
        var t = 0;

        while (true)
        {
            var success = true;

            for (var i = 0; i < max.Length && success; i++)
            {
                if ((t + i + position[i]) % max[i] != 0)
                {
                    success = false;
                }
            }

            if (success)
            {
                return t;
            }

            t++;
        }
    }
}
