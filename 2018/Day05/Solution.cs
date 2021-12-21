using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode._2018.Day05;

[ProblemName("Alchemical Reduction")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        return RunChain(input).Length;
    }

    public object PartTwo(string input)
    {
        Dictionary<char, int> results = new Dictionary<char, int>();

        for (char ch = 'A'; ch <= 'Z'; ch++)
        {
            char chLow = (char)(ch + 32);
            var chain = input.Replace(ch.ToString(), "")
                .Replace(chLow.ToString(), "");


            results.Add(ch, RunChain(chain).Length);
        }

        return results.Min(x => x.Value);
    }

    private static string RunChain(string chain)
    {
        bool changed = true;

        while (changed)
        {
            int i = 0;
            changed = false;
            while (i < chain.Length - 1)
            {
                if (chain[i] + 32 == chain[i + 1] || chain[i] - 32 == chain[i + 1])
                {
                    chain = chain.Remove(i, 2);
                    changed = true;
                }
                else
                {
                    i++;
                }
            }
        }

        return chain;
    }
}
