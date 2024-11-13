namespace AdventOfCode._2018.Day08;

[ProblemName("Memory Maneuver")]      
internal class Solution : ISolver
{
    public object PartOne(string input) => GetNodes(input.Split(' ').Select(int.Parse).ToList(), 0).Item2.Total;

    public object PartTwo(string input) => GetNodes(input.Split(' ').Select(int.Parse).ToList(), 0).Item2.Value;

    private static (int, Node) GetNodes(IReadOnlyList<int> nums, int pointer)
    {
        var numChildren = nums[pointer];
        pointer++;
        var numMetadata = nums[pointer];
        pointer++;

        var node = new Node();

        for (var i = 0; i < numChildren; i++)
        {
            (pointer, var child) = GetNodes(nums, pointer);
            node.Children.Add(child);
        }

        for (var i = 0; i < numMetadata; i++)
        {
            node.Metadata.Add(nums[pointer]);
            pointer++;
        }

        return (pointer, node);
    }

    public class Node
    {
        public List<Node> Children { get; set; } = new();

        public List<int> Metadata { get; set; } = new();

        public int Total => Metadata.Sum() + Children.Sum(x => x.Total);

        public int Value => Children.Count == 0 ? Metadata.Sum() : Metadata.Where(metadata => metadata >= 1 && metadata <= Children.Count).Sum(metadata => Children[metadata - 1].Value);
    }
}
