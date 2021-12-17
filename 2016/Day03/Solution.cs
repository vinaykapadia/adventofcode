using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode._2016.Day03;

[ProblemName("Squares With Three Sides")]      
internal class Solution : Solver
{

    public object PartOne(string input) => input.Lines()
            .Select(line => Regex.Matches(line, "\\d+")
                .Select(x => int.Parse(x.Value))
                .OrderBy(x => x)
                .ToArray())
            .Count(dims => dims[0] + dims[1] > dims[2]);
    
    public object PartTwo(string input)
    {
        var dims = Regex.Matches(input, "\\d+").Select(x => int.Parse(x.Value)).ToArray();
        var count = 0;
        for (var i = 0; i < dims.Length; i += 9)
        {
            for (var j = i; j < i + 3; j++)
            {
                var triangle = new List<int> { dims[j], dims[j + 3], dims[j + 6] };
                triangle = triangle.OrderBy(x => x).ToList();
                if (triangle[0] + triangle[1] > triangle[2]) count++;
            }
        }

        return count;
    }
}
