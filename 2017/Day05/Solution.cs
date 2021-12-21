using System.Linq;

namespace AdventOfCode._2017.Day05;

[ProblemName("A Maze of Twisty Trampolines, All Alike")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        int[] instructions = input.Lines().Select(int.Parse).ToArray();
        int pointer = 0;
        int steps = 0;

        while (pointer >= 0 && pointer < instructions.Length)
        {
            int inst = instructions[pointer];
            
            instructions[pointer]++;

            pointer += inst;
            steps++;
        }

        return steps;
    }

    public object PartTwo(string input)
    {
        int[] instructions = input.Lines().Select(int.Parse).ToArray();
        int pointer = 0;
        int steps = 0;

        while (pointer >= 0 && pointer < instructions.Length)
        {
            int inst = instructions[pointer];
            
            if (inst >= 3) instructions[pointer]--;
            else instructions[pointer]++;

            pointer += inst;
            steps++;
        }

        return steps;
    }
}
