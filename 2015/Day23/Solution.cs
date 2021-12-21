using System.Collections.Generic;

namespace AdventOfCode._2015.Day23;

[ProblemName("Opening the Turing Lock")]      
internal class Solution : ISolver
{
    public object PartOne(string input) => Run(input.Lines(), 0);

    public object PartTwo(string input) => Run(input.Lines(), 1);

    private static int Run(IReadOnlyList<string> lines, int startA)
    {
        int regA = startA, regB = 0;

        for (var line = 0; line < lines.Count;)
        {
            var ins = lines[line];
            if (ins.StartsWith("inc"))
            {
                if (ins[4] == 'a') regA++;
                else regB++;
                line++;
            }
            else if (ins.StartsWith("hlf"))
            {
                if (ins[4] == 'a') regA /= 2;
                else regB /= 2;
                line++;
            }
            else if (ins.StartsWith("tpl"))
            {
                if (ins[4] == 'a') regA *= 3;
                else regB *= 3;
                line++;
            }
            else if (ins.StartsWith("jmp"))
            {
                var num = int.Parse(ins[5..]);
                if (ins[4] == '-') num = -num;
                line += num;
            }
            else
            {
                var regVal = ins[4] == 'a' ? regA : regB;
                if ((ins[2] == 'e' && regVal % 2 == 0) || (regVal == 1))
                {
                    var num = int.Parse(ins[8..]);
                    if (ins[7] == '-') num = -num;
                    line += num;
                }
                else
                {
                    line++;
                }
            }
        }

        return regB;
    }
}
