namespace AdventOfCode._2022.Day02;

[ProblemName("Rock Paper Scissors")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        int score = 0;
        foreach (var line in input.Lines())
        {
            switch (line)
            {
                case "A X":
                    score += 1 + 3;
                    break;
                case "A Y":
                    score += 2 + 6;
                    break;
                case "A Z":
                    score += 3 + 0;
                    break;
                case "B X":
                    score += 1 + 0;
                    break;
                case "B Y":
                    score += 2 + 3;
                    break;
                case "B Z":
                    score += 3 + 6;
                    break;
                case "C X":
                    score += 1 + 6;
                    break;
                case "C Y":
                    score += 2 + 0;
                    break;
                case "C Z":
                    score += 3 + 3;
                    break;
            }
        }
        return score;
    }

    public object PartTwo(string input)
    {
        int score = 0;
        foreach (var line in input.Lines())
        {
            switch (line)
            {
                case "A X":
                    score += 3 + 0;
                    break;
                case "A Y":
                    score += 1 + 3;
                    break;
                case "A Z":
                    score += 2 + 6;
                    break;
                case "B X":
                    score += 1 + 0;
                    break;
                case "B Y":
                    score += 2 + 3;
                    break;
                case "B Z":
                    score += 3 + 6;
                    break;
                case "C X":
                    score += 2 + 0;
                    break;
                case "C Y":
                    score += 3 + 3;
                    break;
                case "C Z":
                    score += 1 + 6;
                    break;
            }
        }
        return score;
    }
}
