using AdventOfCode.Common;

namespace AdventOfCode._2016.Day05;

[ProblemName("How About a Nice Game of Chess?")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        string pw = "";
        int i = 0;
        
        while (pw.Length < 8)
        {
            string hash = Utilities.CalculateMd5Hash(input + i);
            if (hash.StartsWith("00000"))
            {
                pw += hash[5];
            }

            i++;
        }

        return pw.ToLower();
    }

    public object PartTwo(string input)
    {
        var pw = "________";
        var i = 0;

        while (pw.Contains("_"))
        {
            string hash = Utilities.CalculateMd5Hash(input + i);
            if (hash.StartsWith("00000"))
            {
                if (int.TryParse(hash[5].ToString(), out int pos) && pos < 8 && pw[pos] == '_')
                {
                    pw = pw[..pos] + hash[6] + pw[(pos + 1)..];
                }
            }

            i++;
        }

        return pw.ToLower();
    }
}
