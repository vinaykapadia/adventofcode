using System.Diagnostics;

namespace AdventOfCode._2022.Day06;

[ProblemName("Tuning Trouble")]      
internal class Solution : ISolver
{

    public object PartOne(string input) => GetStart(input, 4);

    public object PartTwo(string input) => GetStart(input, 14);

    private static int GetStart(string input, int count)
    {
        for (var i = 0; i < input.Length - count; i++)
        {
            var list = input.Skip(i).Take(count).ToList();
            if (list.Distinct().Count() == list.Count)
            {
                return i + count;
            }
        }

        return -1;
    }
}
