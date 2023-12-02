namespace AdventOfCode._2023.Day01;

[ProblemName("Trebuchet?!")]      
internal class Solution : ISolver
{
    private const string Digits = "0123456789";

    public object PartOne(string input) =>
        input.Lines().Sum(line => int.Parse(line.FirstOrDefault(x => Digits.Contains(x)).ToString()) * 10
                                  + int.Parse(line.LastOrDefault(x => Digits.Contains(x)).ToString()));

    public object PartTwo(string input)
    {
        var tokens = new Dictionary<string, string>
        {
            { "one", "o1e" },
            { "two", "t2o" },
            { "three", "t3e" },
            { "four", "f4r" },
            { "five", "f5e" },
            { "six", "s6x" },
            { "seven", "s7n" },
            { "eight", "e8t" },
            { "nine", "n9e" }
        };
        
        return input.Lines()
            .Select(line => tokens.Aggregate(line, (current, token) => current.Replace(token.Key, token.Value)))
            .Sum(fixedLine => int.Parse(fixedLine.FirstOrDefault(x => Digits.Contains(x)).ToString()) * 10
                              + int.Parse(fixedLine.LastOrDefault(x => Digits.Contains(x)).ToString()));
    }
}
