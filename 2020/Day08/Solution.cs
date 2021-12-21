namespace AdventOfCode._2020.Day08;

[ProblemName("Handheld Halting")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        var lines = input.Lines();
        IList<int> seen = new List<int>();
        int ptr = 0;
        int acc = 0;

        while (!seen.Contains(ptr))
        {
            seen.Add(ptr);
            if (lines[ptr][..3] == "nop")
            {
                ptr++;
            }
            else if (lines[ptr][..3] == "acc")
            {
                acc += int.Parse(lines[ptr][4..]);
                ptr++;
            }
            else if (lines[ptr][..3] == "jmp")
            {
                ptr += int.Parse(lines[ptr][4..]);
            }
        }

        return acc;
    }

    public object PartTwo(string input)
    {
        var lines = input.Lines();
        IList<int> seen = new List<int>();
        int ptr = 0;
        int acc = 0;

        for (var line = 0; line < lines.Length; line++)
        {
            if (lines[line][..3] == "acc") continue;
            ptr = 0;
            acc = 0;
            seen = new List<int>();
            while (ptr < lines.Length && !seen.Contains(ptr))
            {
                seen.Add(ptr);
                if (lines[ptr][..3] == "acc")
                {
                    acc += int.Parse(lines[ptr][4..]);
                    ptr++;
                }
                else if (ptr == line)
                {
                    if (lines[ptr][..3] == "jmp")
                    {
                        ptr++;
                    }
                    else if (lines[ptr][..3] == "nop")
                    {
                        ptr += int.Parse(lines[ptr][4..]);
                    }
                }
                else
                {
                    if (lines[ptr][..3] == "nop")
                    {
                        ptr++;
                    }
                    else if (lines[ptr][..3] == "jmp")
                    {
                        ptr += int.Parse(lines[ptr][4..]);
                    }
                }
            }

            if (ptr == lines.Length)
            {
                return acc;
            }
        }

        return 0;
    }
}
