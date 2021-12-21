using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2015.Day24;

[ProblemName("It Hangs in the Balance")]      
internal class Solution : ISolver {
    private static List<int> _presents;
    private static readonly List<List<int>> PresentSets = new();

    private static int _weightNeeded;

    public object PartOne(string input) => Run(input.Lines(), 3);

    public object PartTwo(string input) => Run(input.Lines(), 4);

    private static long Run(IReadOnlyCollection<string> lines, int groups)
    {
        _presents = lines.Select(int.Parse).OrderBy(x => x).ToList();
        _weightNeeded = _presents.Sum() / groups;

        for (var i = 0; i < lines.Count; i++)
        {
            var indices = new List<int> { i };
            CalculatePresents(indices, i + 1);
        }
        
        var minPresents = PresentSets.Min(x => x.Count);

        var minSets = PresentSets.Where(x => x.Count == minPresents).ToList();

        var quantums = minSets.Select(set => set.Aggregate<int, long>(1, (current, present) => current * _presents[present])).ToList();

        return quantums.Min();
    }

    private static void CalculatePresents(IReadOnlyCollection<int> indices, int startNum)
    {
        var currentTotal = indices.Sum(index => _presents[index]);

        if (currentTotal == _weightNeeded)
        {
            PresentSets.Add(new List<int>(indices));
        }

        if (currentTotal > _weightNeeded)
        {
            return;
        }
        for (var i = startNum; i < _presents.Count; i++)
        {
            var newIndices = new List<int>(indices) { i };
            CalculatePresents(newIndices, i + 1);
        }
    }
}
