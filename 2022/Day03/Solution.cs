namespace AdventOfCode._2022.Day03;

[ProblemName("Rucksack Reorganization")]      
internal class Solution : ISolver
{
    public object PartOne(string input)
    {
        return input.Lines().Sum(elf => elf.Take(elf.Length / 2).Intersect(elf.Skip(elf.Length / 2)).Sum(item => item - (item > 'Z' ? 96 : 38)));
    }

    public object PartTwo(string input)
    {
        var elves = input.Lines();
        var pri = 0;
        for (var i = 0; i < elves.Length; i += 3)
        {
            pri += elves[i].Intersect(elves[i + 1]).Intersect(elves[i + 2]).Sum(item => item - (item > 'Z' ? 96 : 38));
        }

        return pri;
    }
}
