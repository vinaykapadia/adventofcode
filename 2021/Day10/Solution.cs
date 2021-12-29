namespace AdventOfCode._2021.Day10;

[ProblemName("Syntax Scoring")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        int score = 0;
        var bScores = new List<long>();
        foreach (var line in input.Lines())
        {
            Stack<char> parser = new();
            bool corrupted = false;
            foreach (var c in line)
            {
                if (c is '(' or '[' or '{' or '<')
                {
                    parser.Push(c);
                }
                else
                {
                    var last = parser.Pop();
                    if ((c == ')' && last != '(') ||
                        (c == ']' && last != '[') ||
                        (c == '}' && last != '{') ||
                        (c == '>' && last != '<'))
                    {
                        corrupted = true;
                        score += c switch
                        {
                            ')' => 3,
                            ']' => 57,
                            '}' => 1197,
                            '>' => 25137,
                            _ => throw new NotImplementedException()
                        };
                        break;
                    }
                }
            }

            if (corrupted) continue;

            long bScore = 0;
            while (parser.TryPop(out var last))
            {
                bScore *= 5;
                bScore += last switch
                {
                    '(' => 1,
                    '[' => 2,
                    '{' => 3,
                    '<' => 4,
                    _ => throw new NotImplementedException()
                };
            }

            bScores.Add(bScore);
        }

        var sortedList = bScores.OrderBy(x => x).ToList();
        PartBAnswer = sortedList[sortedList.Count / 2];
        return score;
    }

    public object PartTwo(string input)
    {
        return PartBAnswer;
    }
}
