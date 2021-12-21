namespace AdventOfCode._2020.Day01;

[ProblemName("Report Repair")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        var nums = input.Lines().Select(int.Parse).ToArray();
        for (var i = 0; i < nums.Length; i++)
        {
            for (var j = i + 1; j < nums.Length; j++)
            {
                if (nums[j] + nums[i] == 2020) return nums[j] * nums[i];
            }
        }

        return 0;
    }

    public object PartTwo(string input)
    {
        var nums = input.Lines().Select(int.Parse).ToArray();

        for (var i = 0; i < nums.Length; i++)
        {
            for (var j = i + 1; j < nums.Length; j++)
            {
                for (var k = j + 1; k < nums.Length; k++)
                {
                    if (nums[j] + nums[i] + nums[k] == 2020) return nums[j] * nums[i] * nums[k];
                }
            }
        }

        return 0;
    }
}
