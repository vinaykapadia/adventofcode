using System.Linq;

namespace AdventOfCode._2017.Day02;

[ProblemName("Corruption Checksum")]      
internal class Solution : ISolver
{
    public static int Part2Answer { get; set; }

    public object PartOne(string input)
    {
        int partOne = 0, partTwo = 0;
        foreach (var line in input.Lines())
        {
            var items = line.Split('\t').Select(int.Parse).ToList();

            // Part One
            int add = items.Max() - items.Min();
            partOne += add;

            // Part Two
            bool looking = true;
            for (int i = 0; i < items.Count && looking; i++)
            {
                for (int j = 0; j < items.Count && looking; j++)
                {
                    if (i == j) continue;
                    if (items[i] % items[j] == 0)
                    {
                        partTwo += items[i] / items[j];
                        looking = false;
                    }
                }
            }
        }

        Part2Answer = partTwo;
        return partOne;
    }

    public object PartTwo(string input)
    {
        return Part2Answer;
    }
}
