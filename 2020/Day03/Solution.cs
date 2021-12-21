namespace AdventOfCode._2020.Day03;

[ProblemName("Toboggan Trajectory")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        var lines = input.Lines();
        var partA = Slide(lines, 1, 3);
        PartBAnswer = Slide(lines, 1, 1)
                      * partA
                      * Slide(lines, 1, 5)
                      * Slide(lines, 1, 7)
                      * Slide(lines, 2, 1);

        return partA;
    }

    public object PartTwo(string input)
    {
        return PartBAnswer;
    }

    private static uint Slide(string[] input, int down, int right)
    {
        var row = 0;
        var col = 0;
        uint numTrees = 0;

        while (row < input.Length)
        {
            if (input[row][col] == '#') numTrees++;
            row += down;
            col = (col + right) % input[0].Length;
        }

        return numTrees;
    }
}
