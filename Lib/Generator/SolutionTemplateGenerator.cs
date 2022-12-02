using AdventOfCode.Model;

namespace AdventOfCode.Lib.Generator;

class SolutionTemplateGenerator {
    public string Generate(Problem problem) {
        return $@"namespace AdventOfCode._{problem.Year}.Day{problem.Day.ToString("00")};
             |
             |[ProblemName(""{problem.Title}"")]      
             |internal class Solution : ISolver
             |{{
             |
             |    public object PartOne(string input)
             |    {{
             |        return 0;
             |    }}
             |
             |    public object PartTwo(string input)
             |    {{
             |        return 0;
             |    }}
             |}}
             |".StripMargin();
    }
}
