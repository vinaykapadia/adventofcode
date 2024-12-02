using System.Text.RegularExpressions;

namespace AdventOfCode._2024.Day01;

[ProblemName("Historian Hysteria")]      
internal class Solution : ISolver
{
	List<int> list1 = [];
	List<int> list2 = [];
	
	public object PartOne(string input)
    {
	    foreach (var line in input.Lines())
	    {
		    var nums = Regex.Matches(line, "\\d+").Select(x => int.Parse(x.Value)).ToArray();
            list1.Add(nums[0]);
            list2.Add(nums[1]);
	    }

		list1 = list1.OrderBy(x => x).ToList();
		list2 = list2.OrderBy(x => x).ToList();	

	    var sum = list1.Select((t, i) => Math.Abs(t - list2[i])).Sum();

	    return sum;
    }

    public object PartTwo(string input) => list1.Sum(num => num * list2.Count(x => x == num));
}
