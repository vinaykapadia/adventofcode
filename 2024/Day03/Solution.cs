using System.Text.RegularExpressions;

namespace AdventOfCode._2024.Day03;

[ProblemName("Mull It Over")]      
internal class Solution : ISolver
{
    public object PartOne(string input) => Regex.Matches(input, @"mul\(\d+,\d+\)").Sum(y => Regex.Matches(y.Value, "\\d+").Select(x => int.Parse(x.Value)).Aggregate((x, y) => x * y));

    public object PartTwo(string input)
	{
		var sum = 0;
		var on = true;

		foreach (Match mul in Regex.Matches(input, @"(mul\(\d+,\d+\)|do\(\)|don't\(\))"))
		{
            if (mul.Value == "do()")
            {
	            on = true;
            }
            else if (mul.Value == "don't()")
            {
	            on = false;
            }
            else if (on)
            {
	            var nums = Regex.Matches(mul.Value, "\\d+").Select(x => int.Parse(x.Value)).ToArray();
	            sum += nums.Aggregate((x, y) => x * y);
            }
		}

		return sum;
	}
}
