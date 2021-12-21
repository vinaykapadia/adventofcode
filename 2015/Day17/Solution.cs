using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace AdventOfCode._2015.Day17;

[ProblemName("No Such Thing as Too Much")]      
internal class Solution : ISolver {
    private static List<int> _buckets;
    private static int _count;
    private static readonly List<int> BucketCounts = new();

    public object PartOne(string input) {
        _buckets = input.Lines().Select(int.Parse).OrderBy(x => x).ToList();

        for (var i = 0; i < input.Lines().Length; i++)
        {
            var indices = new List<int> { i };
            CalculateBuckets(indices, i + 1);
        }

        return _count;
    }

    public object PartTwo(string input) {
        var minBuckets = BucketCounts.Min();
        return BucketCounts.Count(x => x == minBuckets);
    }

    private static void CalculateBuckets(IReadOnlyCollection<int> indices, int startNum)
    {
        var currentTotal = indices.Sum(index => _buckets[index]);

        switch (currentTotal)
        {
            case 150:
                _count++;
                BucketCounts.Add(indices.Count);
                break;
            case > 150:
                return;
        }

        for (var i = startNum; i < _buckets.Count; i++)
        {
            var newIndices = new List<int>(indices) { i };
            CalculateBuckets(newIndices, i + 1);
        }
    }
}
