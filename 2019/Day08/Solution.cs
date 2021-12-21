namespace AdventOfCode._2019.Day08;

[ProblemName("Space Image Format")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        var width = 25;
        var height = 6;

        var zeroCount = int.MaxValue;
        var val = 0;
        
        var layers = Enumerable.Range(0, input.Length / (width * height)).Select(i => input.Substring(i * width * height, width * height).ToCharArray()).ToList();
        foreach (var layer in layers)
        {
            var layerZeroCount = layer.Count(x => x == '0');
            if (layerZeroCount < zeroCount)
            {
                zeroCount = layerZeroCount;
                val = layer.Count(x => x == '1') * layer.Count(x => x == '2');
            }
        }

        return val;
    }

    public object PartTwo(string input)
    {
        var width = 25;
        var height = 6;
        char[] merged = new char[width * height];
        var layers = Enumerable.Range(0, input.Length / (width * height)).Select(i => input.Substring(i * width * height, width * height).ToCharArray()).ToList();


        for (int i = 0; i < width * height; i++)
        {
            int visibleLayer = 0;
            while (layers[visibleLayer][i] == '2') visibleLayer++;
            merged[i] = layers[visibleLayer][i];
        }

        var index = 0;

        foreach (var c in merged)
        {
            Console.Write(c == '0' ? ' ' : '*');
            index++;
            if (index == width)
            {
                index = 0;
                Console.WriteLine();
            }
        }

        // Value taken from output above.
        return "CYUAH";
    }
}
