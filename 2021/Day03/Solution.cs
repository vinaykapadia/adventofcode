namespace AdventOfCode._2021.Day03;

[ProblemName("Binary Diagnostic")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        var numOnes = new int[12];
        var numZeros = new int[12];

        foreach (var line in input.Lines())
        {
            for (var i = 0; i < 12; i++)
            {
                if (line[i] == '0') numZeros[i]++;
                if (line[i] == '1') numOnes[i]++;
            }
        }

        string gamma = "";
        string epsilon = "";

        for (var i = 0; i < 12; i++)
        {
            gamma += numOnes[i] > numZeros[i] ? "1" : "0";
            epsilon += numOnes[i] > numZeros[i] ? "0" : "1";
        }

        return Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2);
    }

    public object PartTwo(string input)
    {
        var lines = input.Lines();
        var j = 0;

        while (lines.Length > 1)
        {
            int numZero = 0;
            int numOne = 0;
            foreach (var line in lines)
            {
                if (line[j] == '0') numZero++;
                if (line[j] == '1') numOne++;
            }

            char check = numOne >= numZero ? '1' : '0';
            lines = lines.Where(x => x[j] == check).ToArray();

            j++;
        }

        int oxygen = Convert.ToInt32(lines[0], 2);

        lines = input.Lines();
        
        j = 0;

        while (lines.Length > 1)
        {
            int numZero = 0;
            int numOne = 0;
            foreach (var line in lines)
            {
                if (line[j] == '0') numZero++;
                if (line[j] == '1') numOne++;
            }

            char check = numOne >= numZero ? '0' : '1';
            lines = lines.Where(x => x[j] == check).ToArray();

            j++;
        }

        int co2 = Convert.ToInt32(lines[0], 2);

        return oxygen * co2;
    }
}
