using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode._2017.Day06;

[ProblemName("Memory Reallocation")]      
internal class Solution : ISolver
{
    public static int PartBAnswer { get; set; }

    public object PartOne(string input)
    {
        var banks = input.Split('\t').Select(int.Parse).ToArray();
        var seen = new List<string> { ArrayToString(banks) };
        var found = false;
        var cycles = 0;

        while (!found)
        {
            int max = 0;
            int index = 0;
            for (int i = 0; i < banks.Length; i++)
            {
                if (banks[i] > max)
                {
                    max = banks[i];
                    index = i;
                }
            }

            banks[index] = 0;
            index++;
            index %= banks.Length;

            while (max > 0)
            {
                max--;
                banks[index]++;
                index++;
                index %= banks.Length;
            }

            cycles++;
            var item = ArrayToString(banks);
            if (seen.Contains(item)) found = true;
            seen.Add(item);
        }

        var first = seen.IndexOf(seen.Last());
        PartBAnswer = seen.Count - first - 1;

        return cycles;
    }

    public object PartTwo(string input)
    {
        return PartBAnswer;
    }

    private static string ArrayToString<T>(IEnumerable<T> array)
    {
        var sb = new StringBuilder();
        foreach (var item in array)
        {
            sb.Append(item);
            sb.Append(' ');
        }

        return sb.ToString();
    }
}
