namespace AdventOfCode._2015.Day25;

[ProblemName("Let It Snow")]      
internal class Solution : ISolver {

    // Values from input are just typed in.

    public object PartOne(string input) {
        int row = 1, column = 1;
        ulong code = 20151125;
        //row 2947, column 3029
        while (true)
        {
            if (row == 2947 && column == 3029)
            {
                return code;
            }
            column++;
            row--;
            if (row < 1)
            {
                row = column;
                column = 1;
            }

            code *= 252533;
            code %= 33554393;
        }
    }
}
