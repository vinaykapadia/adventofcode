using System.Text.RegularExpressions;

namespace AdventOfCode._2022.Day04;

[ProblemName("Camp Cleanup")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        var count = 0;
        foreach (var line in input.Lines())
        {
            var nums = Regex.Split(line, @"\D+").Select(int.Parse).ToList();
            if (nums[0] <= nums[2] && nums[1] >= nums[3]) count++;
            else if (nums[0] >= nums[2] && nums[1] <= nums[3]) count++;
        }
        return count;
    }
    
    public object PartTwo(string input)
    {
        return input.Lines().Select(line => Regex.Split(line, @"\D+").Select(int.Parse).ToList()).Count(nums => nums[0] <= nums[3] && nums[2] <= nums[1]);
    }
}
