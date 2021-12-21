using AdventOfCode.Common;

namespace AdventOfCode._2017.Day09;

[ProblemName("Stream Processing")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        int garbage = 0;

        int i = 0;
        while (i < input.Length)
        {
            // remove cancelled
            if (input[i] == '!')
            {
                input = input.Remove(i, 2);
            }
            else i++;
        }

        i = 0;
        while (i < input.Length)
        {
            // remove garbage
            if (input[i] == '<')
            {
                int count = 1;
                while (input[i + count] != '>')
                {
                    count++;
                }

                garbage += count - 1;
                input = input.Remove(i, count + 1);
            }
            else i++;
        }

        int depth = 0;
        int score = 0;
        foreach (var c in input)
        {
            if (c == '{')
            {
                depth++;
                score += depth;
            }

            if (c == '}')
            {
                depth--;
            }
        }

        Utilities.PartBAnswer = garbage;
        return score;
    }

    public object PartTwo(string input)
    {
        return Utilities.PartBAnswer;
    }
}
