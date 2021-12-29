using System.Text;

namespace AdventOfCode._2021.Day08;

[ProblemName("Seven Segment Search")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        var outputs = input.Lines().Select(x => x.Split(" | ")[1].Split(' '));
        return outputs.Sum(x => x.Count(y => y.Length is 2 or 3 or 4 or 7));
    }

    public object PartTwo(string input)
    {
        return input.Lines().Sum(ProcessLine);
    }

    private static int ProcessLine(string input)
    {
        var lookup = new Dictionary<string, int>
        {
            { "abcefg", 0 },
            { "cf", 1 },
            { "acdeg", 2 },
            { "acdfg", 3 },
            { "bcdf", 4 },
            { "abdfg", 5 },
            { "abdefg", 6 },
            { "acf", 7 },
            { "abcdefg", 8 },
            { "abcdfg", 9 },
        };

        var inputs = input.Split(" | ")[0].Split(' ');
        var outputs = input.Split(" | ")[1].Split(' ');

        var choices = new Dictionary<char, List<char>>()
        {
            { 'a', new List<char>() },
            { 'b', new List<char>() },
            { 'c', new List<char>() },
            { 'd', new List<char>() },
            { 'e', new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g' } },
            { 'f', new List<char>() },
            { 'g', new List<char>() },
        };

        var num7 = inputs.First(x => x.Length == 3); // 7
        var num1 = inputs.First(x => x.Length == 2); // 17
        var num4 = inputs.First(x => x.Length == 4); // 147

        choices['a'].Add(num7.First(x => !num1.Contains(x))); // A
        choices['b'] = num4.Where(x => !num1.Contains(x)).ToList();
        choices['d'] = num4.Where(x => !num1.Contains(x)).ToList();

        var num5 = inputs.First(x => x.Length == 5 && choices['b'].All(x.Contains)); // 1457

        choices['g'] = num5.Where(x => !choices['b'].Contains(x) && !choices['a'].Contains(x)).ToList();
        
        var num2 = inputs.First(x => x.Length == 5 && x != num5 && !choices['g'].All(x.Contains)); // 12457
        var num3 = inputs.First(x => x.Length == 5 && x != num5 && x != num2); // 123457

        choices['b'].RemoveAt(num2.Contains(choices['b'][0]) ? 0 : 1); // AB
        choices['d'].Remove(choices['b'][0]); // ABD

        choices['c'].Add(num1.First(x => !num5.Contains(x))); // ABCD

        choices['f'].Add(num7.First(x => !num2.Contains(x))); // ABCDF
        choices['g'].Remove(choices['f'][0]); // ABCDFG

        foreach (var c in num5)
            choices['e'].Remove(c);
        foreach (var c in num3)
            choices['e'].Remove(c);

        var reverseLookup = new Dictionary<char, char>(choices.Select(x => new KeyValuePair<char, char>(x.Value[0], x.Key)));

        int sum = 0;
        for(int i = 0; i < outputs.Length; i++)
        {
            var s = new string(outputs[i].Select(x => reverseLookup[x]).OrderBy(x => x).ToArray());
            int digit = lookup[s];
            sum += digit * (int)Math.Pow(10, 3 - i);
        }

        return sum;
    }
}
