namespace AdventOfCode._2023.Day15;

[ProblemName("Lens Library")]      
internal class Solution : ISolver
{

    public object PartOne(string input) => input.Split(',').Sum(Hash);

    public object PartTwo(string input)
    {
        var boxes = new List<List<Lens>>();

        for (var i = 0; i < 256; i++)
        {
            boxes.Add(new());
        }

        foreach (var instruction in input.Split(","))
        {
            if (instruction.Contains('='))
            {
                var label = instruction[..^2];
                var hash = Hash(label);
                var focal = int.Parse(instruction[^1].ToString());
                var lens = boxes[hash].FirstOrDefault(x => x.Label == label);
                if (lens == null)
                {
                    boxes[hash].Add(new Lens
                    {
                        Label = label,
                        Focal = focal
                    });
                }
                else
                {
                    lens.Focal = focal;
                }
            }
            else
            {
                var label = instruction[..^1];
                var hash = Hash(label);
                var lens = boxes[hash].FirstOrDefault(x => x.Label == label);
                if (lens != null)
                {
                    boxes[hash].Remove(lens);
                }
            }
        }

        var total = 0;
        for (var i = 0; i < 256; i++)
        {
            for (var j = 0; j < boxes[i].Count; j++)
            {
                total += (i + 1) * (j + 1) * boxes[i][j].Focal;
            }
        }

        return total;
    }

    private int Hash(string text) => text.Aggregate(0, Hash);

    private static int Hash(int currentValue, char ch)
    {
        return ((currentValue + ch) * 17) % 256;
    }

    private class Lens
    {
        public string Label { get; set; }

        public int Focal { get; set; }
    }
}
