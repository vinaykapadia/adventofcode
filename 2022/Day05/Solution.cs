using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode._2022.Day05;

[ProblemName("Supply Stacks")]      
internal class Solution : ISolver
{
    public object PartOne(string input)
    {
        var stacks = new Stack<char>[9];

        for (var i = 0; i < 9; i++)
        {
            stacks[i] = new Stack<char>();
        }

        var lines = input.Lines();
        for (var i = 7; i >= 0; i--)
        {
            for (var j = 0; j < 9; j++)
            {
                var c = lines[i][4 * j + 1];
                if (c != ' ')
                {
                    stacks[j].Push(c);
                }
            }
        }

        for (var i = 10; i < lines.Length; i++)
        {
            var split = Regex.Split(lines[i], @"\D+").ToList();
            split.Remove("");
            var nums = split.Select(int.Parse).ToList();
            for (var j = 0; j < nums[0]; j++)
            {
                var c = stacks[nums[1]-1].Pop();
                stacks[nums[2]-1].Push(c);
            }
        }

        StringBuilder b = new StringBuilder();
        for (var i = 0; i < 9; i++)
        {
            b.Append(stacks[i].Pop());
        }

        return b.ToString();
    }

    public object PartTwo(string input)
    {
        var stacks = new Stack<char>[9];

        for (var i = 0; i < 9; i++)
        {
            stacks[i] = new Stack<char>();
        }

        var lines = input.Lines();
        for (var i = 7; i >= 0; i--)
        {
            for (var j = 0; j < 9; j++)
            {
                var c = lines[i][4 * j + 1];
                if (c != ' ')
                {
                    stacks[j].Push(c);
                }
            }
        }

        for (var i = 10; i < lines.Length; i++)
        {
            var split = Regex.Split(lines[i], @"\D+").ToList();
            split.Remove("");
            var nums = split.Select(int.Parse).ToList();
            var tempStack = new Stack<char>();
            for (var j = 0; j < nums[0]; j++)
            {
                var c = stacks[nums[1] - 1].Pop();
                tempStack.Push(c);
            }

            for (var j = 0; j < nums[0]; j++)
            {
                var c = tempStack.Pop();
                stacks[nums[2] - 1].Push(c);
            }
        }

        StringBuilder b = new StringBuilder();
        for (var i = 0; i < 9; i++)
        {
            b.Append(stacks[i].Pop());
        }

        return b.ToString();
    }
}
