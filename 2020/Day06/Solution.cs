namespace AdventOfCode._2020.Day06;

[ProblemName("Custom Customs")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        var sumA = 0;
        var seen = new bool[26];
        var sumB = 0;
        var countB = 0;
        var allYes = new AutoAddingDictionary<char, int>();

        foreach (var line in input.Lines())
        {
            if (line == "")
            {
                seen = new bool[26];
                sumB += allYes.Count(x => x.Value == countB);
                countB = 0;
                allYes = new AutoAddingDictionary<char, int>();
            }
            else
            {
                countB++;
                foreach (var c in line)
                {
                    allYes[c]++;
                    if (!seen[c - 'a'])
                    {
                        seen[c - 'a'] = true;
                        sumA++;
                    }
                }
            }
        }
        sumB += allYes.Count(x => x.Value == countB);

        PartBAnswer = sumB;
        return sumA;
    }

    public object PartTwo(string input)
    {
        return PartBAnswer;
    }
}
