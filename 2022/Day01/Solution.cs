namespace AdventOfCode._2022.Day01;

[ProblemName("Calorie Counting")]      
internal class Solution : ISolver
{
    private readonly List<List<int>> _elves = new();

    public object PartOne(string input)
    {
        List<int> elf = new List<int>();

        foreach (var line in input.Lines())
        {
            if (line == "")
            {
                _elves.Add(elf);
                elf = new List<int>();
            }
            else
            {
                elf.Add(int.Parse(line));
            }
        }

        _elves.Add(elf);

        return _elves.Max(x => x.Sum(y => y));
    }

    public object PartTwo(string input)
    {
        return _elves.Select(x => x.Sum(y => y)).OrderByDescending(z => z).Take(3).Sum();
    }
}
