namespace AdventOfCode._2021.Day01;

[ProblemName("Sonar Sweep")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        var lines = input.Lines().Select(int.Parse).ToArray();

        var countA = 0;
        var countB = 0;

        for (var i = 0; i < lines.Length - 3; i++)
        {
            if (lines[i] < lines[i + 1]) countA++;
            if (lines[i] < lines[i + 3]) countB++;
        }

        for (var i = lines.Length - 3; i < lines.Length - 1; i++)
        {
            if (lines[i] < lines[i + 1]) countA++;
        }

        PartBAnswer = countB;
        return countA;
    }

    public object PartTwo(string input)
    {
        return PartBAnswer;
    }
}
