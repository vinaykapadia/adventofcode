namespace AdventOfCode._2022.Day13;

[ProblemName("Distress Signal")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        var pairs = new List<(ThingList Left, ThingList Right)>();

        var lines = input.Lines();
        for (var i = 0; i < lines.Length; i += 3)
        {
            pairs.Add((ParsePacket(lines[i]), ParsePacket(lines[i + 1])));
        }

        return 0;
    }

    public object PartTwo(string input)
    {
        return 0;
    }

    private ThingList ParsePacket(string input)
    {
        return new ThingList();
    }
}

internal interface IThing
{
}

internal class ThingList : IThing
{
    public IList<IThing> Contents { get; } = new List<IThing>();
}

internal class ThingItem : IThing
{
    public int Value { get; set; }
}