using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace AdventOfCode._2015.Day13;

[ProblemName("Knights of the Dinner Table")]      
internal class Solution : ISolver {
    private static Dictionary<string, int> Happiness = new Dictionary<string, int>();
    List<string> names = new List<string>();
    private static int maxHap = 0;
    private static int n;

    public object PartOne(string input) {

        foreach (var line in input.Replace(".", "").Split('\n'))
        {
            string sourceName = line.Substring(0, line.IndexOf(' '));
            int i = line.IndexOf(" would ") + 7;
            string rest = line.Substring(i);
            int happiness = int.Parse(rest.Substring(5, rest.IndexOf(' ', 5) - 5));
            if (rest[0] == 'l') happiness *= -1;
            string destName = rest.Substring(rest.IndexOf("next to ") + 8);
            Happiness.Add(sourceName + destName, happiness);
            if (!names.Contains(sourceName)) names.Add(sourceName);
        }

        n = names.Count;
        string[] list = names.ToArray();
        PrnPerm(list, 0, n - 1);

        return maxHap;
    }

    public object PartTwo(string input) {
        maxHap = 0;

        foreach (var name in names)
        {
            Happiness.Add("Vinay" + name, 0);
            Happiness.Add(name + "Vinay", 0);
        }
        names.Add("Vinay");

        n = names.Count;
        string[] list = names.ToArray();
        PrnPerm(list, 0, n - 1);

        return maxHap;
    }

    private static int GetHappiness(string[] list)
    {
        int hap = 0;
        for (int i = 0; i < n; i++)
        {
            string key = list[i] + list[(i + 1) % n];
            hap += Happiness[key];
            key = list[i] + list[(i + n - 1) % n];
            hap += Happiness[key];
        }
        return hap;
    }

    private static void SwapTwoNumber(ref string a, ref string b)
    {
        (a, b) = (b, a);
    }
    private static void PrnPerm(string[] list, int k, int m)
    {
        if (k == m)
        {
            int hap = GetHappiness(list);
            if (hap > maxHap) maxHap = hap;
        }
        else
        {
            for (int i = k; i <= m; i++)
            {
                SwapTwoNumber(ref list[k], ref list[i]);
                PrnPerm(list, k + 1, m);
                SwapTwoNumber(ref list[k], ref list[i]);
            }
        }
    }
}
