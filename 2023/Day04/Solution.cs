using System.Text.RegularExpressions;

namespace AdventOfCode._2023.Day04;

[ProblemName("Scratchcards")]      
internal class Solution : ISolver
{
    private const int WinningNumberCount = 10;

    public object PartOne(string input)
    {
        var total = 0;

        foreach (var line in input.Lines())
        {
            var numbersInLine = Regex.Matches(line, "\\d+");
            var winningNumbers = new List<string>();
            for (var i = 1; i <= WinningNumberCount; i++)
            {
                winningNumbers.Add(numbersInLine[i].Value);
            }

            var matches = 0;
            for (var i = WinningNumberCount + 1; i < numbersInLine.Count; i++)
            {
                if (winningNumbers.Contains(numbersInLine[i].Value))
                {
                    matches++;
                }
            }

            total += (int)Math.Pow(2, matches - 1);
        }

        return total;
    }

    public object PartTwo(string input)
    {
        var lines = input.Lines();
        var count = lines.Length;
        var cardCounts = new List<int>();
        for (var i = 0; i < count; i++)
        {
            cardCounts.Add(1);
        }

        for (var i = 0; i < count; i++)
        {
            var numbersInLine = Regex.Matches(lines[i], "\\d+");
            var winningNumbers = new List<string>();
            for (var j = 1; j <= WinningNumberCount; j++)
            {
                winningNumbers.Add(numbersInLine[j].Value);
            }

            var matches = 0;
            for (var j = WinningNumberCount + 1; j < numbersInLine.Count; j++)
            {
                if (winningNumbers.Contains(numbersInLine[j].Value))
                {
                    matches++;
                }
            }

            for (var j = i + 1; j <= i + matches && j < count; j++)
            {
                cardCounts[j] += cardCounts[i];
            }
        }

        return cardCounts.Sum();
    }
}
