namespace AdventOfCode._2017.Day01;

[ProblemName("Inverse Captcha")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        var partOne = 0;
        for (var i = 0; i < input.Length; i++)
        {
            var j = i + 1;
            if (j == input.Length) j = 0;
            if (input[i] == input[j]) partOne += int.Parse(input[i].ToString());
        }

        return partOne;
    }

    public object PartTwo(string input)
    {
        var partTwo = 0;
        for (var i = 0; i < input.Length; i++)
        {
            var k = (i + input.Length / 2) % input.Length;
            if (input[i] == input[k]) partTwo += int.Parse(input[i].ToString());
        }

        return partTwo;
    }
}
