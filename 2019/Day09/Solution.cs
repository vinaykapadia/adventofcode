namespace AdventOfCode._2019.Day09;

[ProblemName("Sensor Boost")]      
internal class Solution : ISolver
{
    public object PartOne(string input)
    {
        Computer.AddInput(1);
        Computer.Process(input);
        return Computer.LastOutput;
    }

    public object PartTwo(string input)
    {
        Computer.AddInput(2);
        Computer.Process(input);
        return Computer.LastOutput;
    }
}
