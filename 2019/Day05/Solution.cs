using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2019.Day05;

[ProblemName("Sunny with a Chance of Asteroids")]      
internal class Solution : ISolver
{
    private IntcodeComputer Computer = new IntcodeComputer();

    public object PartOne(string input)
    {
        var progList = input.Split(',').Select(long.Parse).ToArray();
        Computer.AddInput(1);
        Computer.InMode = InOutMode.Memory;
        Computer.OutMode = InOutMode.Memory;
        progList = Computer.Process(progList);
        return Computer.LastOutput;
    }

    public object PartTwo(string input)
    {
        var progList = input.Split(',').Select(long.Parse).ToArray();
        Computer.AddInput(5);
        Computer.InMode = InOutMode.Memory;
        Computer.OutMode = InOutMode.Memory;
        progList = Computer.Process(progList);
        return Computer.LastOutput;
    }
}
