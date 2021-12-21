namespace AdventOfCode._2015.Day01;

[ProblemName("Not Quite Lisp")]      
internal class Solution : ISolver {

    public object PartOne(string input)
    {
        var floor = 0;
        foreach (var c in input)
        {
            if (c == '(') floor++;
            if (c == ')') floor--;
        }

        return floor;
    }

    public object PartTwo(string input) {
        var floor = 0;
        for (var i = 0; i < input.Length; i++)
        {
            if (input[i] == '(') floor++;
            if (input[i] == ')') floor--;
            if (floor == -1) return i + 1;
        }

        return -1;
    }
}
