namespace AdventOfCode._2018.Day14;

[ProblemName("Chocolate Charts")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        // Just typing in the input here.
        const int recipes = 580741;

        var scores = new List<int> { 3, 7 };

        int elf1 = 0;
        int elf2 = 1;

        while (scores.Count < recipes + 10)
        {
            var score = scores[elf1] + scores[elf2];
            if (score > 9)
            {
                scores.Add(1);
                score -= 10;
            }

            scores.Add(score);

            elf1 = (elf1 + 1 + scores[elf1]) % scores.Count;
            elf2 = (elf2 + 1 + scores[elf2]) % scores.Count;
        }

        return scores[^10..].Aggregate("", (a, i) => a + i);
    }

	public object PartTwo(string input)
    {
        const string desired = "580741";

        var scores = new List<int> { 3, 7 };

        int elf1 = 0;
        int elf2 = 1;
        var found = false;
        var length = desired.Length;

        while (!found)
        {
            var score = scores[elf1] + scores[elf2];
            if (score > 9)
            {
                scores.Add(1);
                score -= 10;
            }

            scores.Add(score);

            elf1 = (elf1 + 1 + scores[elf1]) % scores.Count;
            elf2 = (elf2 + 1 + scores[elf2]) % scores.Count;

            if (scores.Count > length && scores[^length..].Aggregate("", (a, i) => a + i) == desired)
            {
                found = true;
            }
        }
        //141032488 too high
        //141032487 too high
        return scores.Count - length;
    }
}
