namespace AdventOfCode._2023.Day09;

[ProblemName("Mirage Maintenance")]      
internal class Solution : ISolver
{

    public object PartOne(string input) => input.Lines().Sum(line => GetNext(line.Split(' ').Select(int.Parse).ToList()));

    public object PartTwo(string input) => input.Lines().Sum(line => GetNext(line.Split(' ').Select(int.Parse).ToList(), true));

    private static int GetNext(List<int> values, bool isPrevious = false)
    {
        if (values.All(x => x == 0))
        {
            return 0;
        }

        var nextValues = new List<int>();
        for (var i = 1; i < values.Count; i++)
        {
            nextValues.Add(values[i] - values[i - 1]);
        }

        var currentValue = isPrevious ? values[0] : values[^1];
        var sign = isPrevious ? -1 : 1;
        return currentValue + GetNext(nextValues, isPrevious) * sign;
    }
}
