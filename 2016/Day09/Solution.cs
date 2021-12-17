namespace AdventOfCode._2016.Day09;

[ProblemName("Explosives in Cyberspace")]      
internal class Solution : Solver
{

    public object PartOne(string input)
    {
        string output = "";
        int i = 0;
        while (i < input.Length)
        {
            if (input[i] != '(')
            {
                output += input[i];
                i++;
            }
            else
            {
                i++;
                string num1 = "", num2 = "";
                while (input[i] >= '0' && input[i] <= '9')
                {
                    num1 += input[i];
                    i++;
                }
                i++;
                while (input[i] >= '0' && input[i] <= '9')
                {
                    num2 += input[i];
                    i++;
                }
                i++;
                string repeat = "";
                for (int j = 0; j < int.Parse(num1); j++)
                {
                    repeat += input[i];
                    i++;
                }

                for (int j = 0; j < int.Parse(num2); j++)
                {
                    output += repeat;
                }
            }
        }

        return output.Length;
    }

    public object PartTwo(string input)
    {
        return Decompress(input);
    }

    private static long Decompress(string text)
    {
        if (!text.Contains('(')) return text.Length;
        string first = text.Substring(0, text.IndexOf('('));
        long length = first.Length;
        text = text.Substring(first.Length);
        int i = 1;
        string num1 = "", num2 = "";
        while (text[i] >= '0' && text[i] <= '9')
        {
            num1 += text[i];
            i++;
        }
        i++;
        while (text[i] >= '0' && text[i] <= '9')
        {
            num2 += text[i];
            i++;
        }
        i++;
        string repeat = "";
        for (int j = 0; j < int.Parse(num1); j++)
        {
            repeat += text[i];
            i++;
        }

        length += int.Parse(num2) * Decompress(repeat);
        string rest = text.Substring(i);
        length += Decompress(rest);
        return length;
    }
}
