using System.ComponentModel;

namespace AdventOfCode._2021.Day06;

[ProblemName("Lanternfish")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        var fish = input.Split(',').Select(int.Parse).ToList();
        return RunFish(fish, 80);
    }
    
    public object PartTwo(string input)
    {
        var nums = input.Split(',').Select(int.Parse).ToList();
        return RunFish(nums, 256);
    }

    private static long RunFish(IList<int> start, int days)
    {
        var fishes = new long[9];
        for (var i = 0; i < 9; i++)
        {
            fishes[i] = start.Count(x => x == i);
        }

        for (var i = 0; i < days; i++)
        {
            (fishes[0], fishes[1], fishes[2], fishes[3], fishes[4], fishes[5], fishes[6], fishes[7], fishes[8]) =
                (fishes[1], fishes[2], fishes[3], fishes[4], fishes[5], fishes[6], fishes[7] + fishes[0], fishes[8], fishes[0]);
        }

        return fishes.Sum();
    }
}
