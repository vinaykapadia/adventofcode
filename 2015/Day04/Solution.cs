using AdventOfCode.Common;

namespace AdventOfCode._2015.Day04;

[ProblemName("The Ideal Stocking Stuffer")]      
internal class Solution : ISolver {

    public object PartOne(string input)
    {
        int num = 1;
        while (true)
        {
            var hash = Utilities.CalculateMd5Hash(input + num);
            if (hash[..5] == "00000")
            {
                return num;
            }

            num++;
        }
    }

    public object PartTwo(string input) {
        int num = 1;
        while (true)
        {
            var hash = Utilities.CalculateMd5Hash(input + num);
            if (hash[..6] == "000000")
            {
                return num;
            }

            num++;
        }
    }
}
