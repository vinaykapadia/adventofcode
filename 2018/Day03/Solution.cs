using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode.Common;

namespace AdventOfCode._2018.Day03;

[ProblemName("No Matter How You Slice It")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        List<int>[,] fabric = new List<int>[1500, 1500];
        Dictionary<int, bool> winner = new Dictionary<int, bool>();

        //#1135 @ 757,77: 22x23
        foreach (var line in input.Lines())
        {
            var split = Regex.Split(line, @"\D+");
            int id = int.Parse(split[1]);
            int left = int.Parse(split[2]);
            int top = int.Parse(split[3]);
            int width = int.Parse(split[4]);
            int height = int.Parse(split[5]);
            winner.Add(id, true);

            for (int i = left; i < left + width; i++)
            for (int j = top; j < top + height; j++)
            {
                if (fabric[i, j] == null) fabric[i, j] = new List<int>();
                fabric[i, j].Add(id);
            }
        }

        int count = 0;

        for (int i = 0; i < 1500; i++)
        for (int j = 0; j < 1500; j++)
        {
            if (fabric[i, j] != null && fabric[i, j].Count > 1)
            {
                foreach (var item in fabric[i, j])
                {
                    winner[item] = false;
                }

                count++;
            }
        }

        Utilities.PartBAnswer = winner.First(x => x.Value).Key;
        return count;
    }

    public object PartTwo(string input)
    {
        return Utilities.PartBAnswer;
    }
}
