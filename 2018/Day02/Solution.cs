using System.Linq;
using AdventOfCode.Common;
using AdventOfCode.Lib;

namespace AdventOfCode._2018.Day02;

[ProblemName("Inventory Management System")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        var lines = input.Lines();

        int countTwo = 0, countThree = 0;
        foreach (var line in lines)
        {
            AutoAddingDictionary<char, int> map = new AutoAddingDictionary<char, int>();
            foreach (var c in line)
            {
                map[c]++;
            }

            if (map.Any(x => x.Value == 2)) countTwo++;
            if (map.Any(x => x.Value == 3)) countThree++;
        }

        int i = 0, j = 0;
        bool found = false;

        while (!found)
        {
            j = i + 1;
            while (!found && j < lines.Length)
            {
                int diff = 0;
                for (int k = 0; k < lines[i].Length; k++)
                {
                    if (lines[i][k] != lines[j][k]) diff++;
                }

                if (diff == 1) found = true;
                else j++;
            }

            if (!found) i++;
        }

        string final = "";

        for (int k = 0; k < lines[i].Length; k++)
        {
            if (lines[i][k] == lines[j][k]) final += lines[i][k];
        }

        Utilities.PartBAnswer = final;
        return countThree * countTwo;
    }

    public object PartTwo(string input)
    {
        return Utilities.PartBAnswer;
    }
}
