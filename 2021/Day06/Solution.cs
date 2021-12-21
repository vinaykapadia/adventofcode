namespace AdventOfCode._2021.Day06;

[ProblemName("Lanternfish")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        var fish = input.Split(',').Select(int.Parse).ToList();

        for (int i = 1; i <= 80; i++)
        {
            int newFish = 0;
            for (int j = 0; j < fish.Count; j++)
            {
                if (fish[j] == 0)
                {
                    newFish++;
                    fish[j] = 6;
                }

                else
                {
                    fish[j]--;
                }
            }

            for (int j = 0; j < newFish; j++)
            {
                fish.Add(8);
            }
        }

        return fish.Count;
    }

    public object PartTwo(string input)
    {
        return 0;
    }
}
