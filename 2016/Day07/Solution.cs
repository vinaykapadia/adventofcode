using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode._2016.Day07;

[ProblemName("Internet Protocol Version 7")]      
internal class Solution : Solver
{
    public static int PartBAnswer { get; set; }

    public object PartOne(string input)
    {
        var lines = input.Lines();
        var tlsLines = new List<string>();
        var sslLines = new List<string>();
        var bothLines = new List<string>();

        var reg = new Regex(@"\[[a-z]+\]");

        foreach (var line in lines)
        {
            var matches = reg.Matches(line);
            List<string> hypernets = new List<string>();

            string newLine = line;
            foreach (var match in matches)
            {
                hypernets.Add(match.ToString());
                newLine = newLine.Replace(match.ToString(), "|");
            }

            List<string> supernets = newLine.Split('|').ToList();

            if (IsTls(supernets, hypernets))
            {
                tlsLines.Add(line);

                if (IsSsl(supernets, hypernets))
                {
                    sslLines.Add(line);
                    bothLines.Add(line);
                }
            }
            else if (IsSsl(supernets, hypernets)) sslLines.Add(line);
        }

        PartBAnswer = sslLines.Count;
        return tlsLines.Count;
    }

    public object PartTwo(string input)
    {
        return PartBAnswer;
    }

    private static bool IsSsl(IEnumerable<string> sup, IEnumerable<string> hyp)
    {
        return sup.Any(seq => GetAba(seq).Any(aba => HasBab(hyp, aba)));
    }

    private static bool HasBab(IEnumerable<string> hyp, string aba)
    {
        foreach (var str in hyp)
        {
            for (int i = 0; i < str.Length - 2; i++)
            {
                if (str[i] == aba[1] && str[i + 1] == aba[0] && str[i + 2] == aba[1])
                    return true;
            }
        }

        return false;
    }

    private static IEnumerable<string> GetAba(string seq)
    {
        for (int i = 0; i < seq.Length - 2; i++)
        {
            if (seq[i] == seq[i + 2] && seq[i] != seq[i + 1])
                yield return seq.Substring(i, 3);
        }
    }

    private static bool IsTls(IEnumerable<string> sup, IEnumerable<string> hyp)
    {
        return !hyp.Any(HasAbba) && sup.Any(HasAbba);
    }

    private static bool HasAbba(string s)
    {
        for (int i = 0; i < s.Length - 3; i++)
        {
            if (s[i] == s[i + 3] && s[i + 1] == s[i + 2] && s[i] != s[i + 1]) return true;
        }

        return false;
    }
}
