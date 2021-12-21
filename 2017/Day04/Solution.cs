using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2017.Day04;

[ProblemName("High-Entropy Passphrases")]      
internal class Solution : ISolver
{
    public static int PartBAnswer { get; set; }

    public object PartOne(string input)
    {
        int partOne = 0, partTwo = 0;
        foreach (var line in input.Lines())
        {
            if (!HasDupes(line.Split(' ')))
            {
                partOne++;
            }
            if (!HasAnagrams(line.Split(' ')))
            {
                partTwo++;
            }
        }

        PartBAnswer = partTwo;
        return partOne;
    }

    public object PartTwo(string input)
    {
        return PartBAnswer;
    }

    private static bool HasDupes(string[] words)
    {
        HashSet<string> singles = new HashSet<string>();
        foreach (var word in words)
        {
            if (singles.Contains(word)) return true;
            singles.Add(word);
        }

        return false;
    }

    private static bool HasAnagrams(string[] words)
    {
        HashSet<string> singles = new HashSet<string>();
        foreach (var word in words)
        {
            string orderedWord = new string(word.OrderBy(x => x).ToArray());
            if (singles.Contains(orderedWord)) return true;
            singles.Add(orderedWord);
        }

        return false;
    }
}
