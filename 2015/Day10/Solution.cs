using System;
using System.Text;

namespace AdventOfCode._2015.Day10;

[ProblemName("Elves Look, Elves Say")]      
internal class Solution : ISolver {

    public object PartOne(string input)
    {
        return BruteForce(input, 40);
    }

    public object PartTwo(string input)
    {
        return BruteForce(input, 50);
    }

    private static int BruteForce(string input, int rounds)
    {
        int length = 0;
        for (var round = 1; round <= rounds; round++)
        {
            StringBuilder sb = new StringBuilder();
            var i = 0;
            while (i < input.Length)
            {
                var n = input[i];
                var count = 0;
                while (i < input.Length && input[i] == n)
                {
                    count++;
                    i++;
                }

                sb.Append(count.ToString() + n);
            }

            input = sb.ToString();
            length = input.Length;
        }

        return length;
    }
}
