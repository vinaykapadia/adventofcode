namespace AdventOfCode._2020.Day09;

[ProblemName("Encoding Error")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        var nums = input.Lines().Select(long.Parse).ToArray();
        long num = 0;

        for (var i = 25; i < nums.Length; i++)
        {
            num = nums[i];
            var fits = false;
            for (var j = i - 25; !fits && j < i; j++)
            {
                for (var k = i - 24; !fits && k < i; k++)
                {
                    if (nums[j] + nums[k] == num)
                    {
                        fits = true;
                    }
                }
            }

            if (!fits)
            {
                break;
            }
        }

        for (var i = 0; i < nums.Length; i++)
        {
            bool? done = null;
            var sum = nums[i];
            int j;
            for (j = i + 1; j < nums.Length && !done.HasValue; j++)
            {
                sum += nums[j];
                if (sum == num)
                {
                    done = true;
                }
                else if (sum > num)
                {
                    done = false;
                }
            }

            if (done ?? false)
            {
                PartBAnswer = nums[i] + nums[j - 1];
                break;
            }
        }

        return num;
    }

    public object PartTwo(string input)
    {
        return PartBAnswer;
    }
}
