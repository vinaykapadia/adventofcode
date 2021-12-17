using AdventOfCode.Lib.Model;

namespace adventofcode.Lib.Generator;

internal class SolutionTemplateGenerator {
    public string Generate(Problem problem) {
        return $@"namespace AdventOfCode._{problem.Year}.Day{problem.Day:00};
             |
             |[ProblemName(""{problem.Title}"")]      
             |internal class Solution : Solver
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
