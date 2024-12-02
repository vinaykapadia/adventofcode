using System.Text.RegularExpressions;

namespace AdventOfCode._2024.Day02;

[ProblemName("Red-Nosed Reports")]      
internal class Solution : ISolver
{
    public object PartOne(string input) => input.Lines().Select(line => Regex.Matches(line, "\\d+").Select(x => int.Parse(x.Value)).ToArray()).Count(CheckLevels);

    public object PartTwo(string input)
	{
		var sum = 0;
		foreach (var line in input.Lines())
		{
			var nums = Regex.Matches(line, "\\d+").Select(x => int.Parse(x.Value)).ToList();

			var safe = false;

			if (CheckLevels(nums))
			{
				safe = true;
			}
			else
			{
				for (var i = 0; i < nums.Count; i++)
				{
					var newNums = new List<int>(nums);
					newNums.RemoveAt(i);
					if (CheckLevels(newNums))
					{
						safe = true;
					}
				}
			}

			if (safe)
			{
				sum++;
			}
		}

		return sum;
	}

	private static bool CheckLevels(IReadOnlyList<int> nums)
	{
		var upMatch = true;
		var downMatch = true;

		for (var i = 0; i < nums.Count - 1; i++)
		{
			if (nums[i] >= nums[i + 1] || nums[i + 1] - nums[i] > 3)
			{
				upMatch = false;
			}

			if (nums[i] <= nums[i + 1] || nums[i] - nums[i + 1] > 3)
			{
				downMatch = false;
			}
		}

		return upMatch || downMatch;
	}
}
