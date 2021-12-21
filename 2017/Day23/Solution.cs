using System.Dynamic;
using AdventOfCode.Lib;

namespace AdventOfCode._2017.Day23;

[ProblemName("Coprocessor Conflagration")]      
internal class Solution : ISolver
{
    private AutoAddingDictionary<char, int> registers = new();
    private int i = 0;

    public object PartOne(string input)
    {
        var numMul = 0;

        var lines = input.Lines();
        while (i < lines.Length)
        {
            var line = lines[i];
            switch (line[2])
            {
                case 't': Set(line[4], line[6..]);
                    break;
                case 'b': Sub(line[4], line[6..]);
                    break;
                case 'l': Mul(line[4], line[6..]);
                    numMul++;
                    break;
                case 'z': Jnz(line[4], line[6..]);
                    break;
            }
        }

        return numMul;
    }

    public object PartTwo(string input)
    {
        var b = 99;
        var g = 2;
        var h = 0;

        while (g != 0)
        {
            var f = true;
            var d = 2;
            g = d;
            while (g != 0)
            {
                var e = 2;
                while (g != 0)
                {
                    g = d;
                    g *= e;
                    g -= b;
                    if (g == 0) f = false;
                    e++;
                    g = e;
                    g -= b;
                }

                d++;
                g = d;
                g -= b;
            }
            
            if (f) h++;
            g = b;
            g -= 99;
            b -= 17;
        }

        return h;
    }

    private void Set(char reg, string source)
    {
        if (source == null) return;

        if (!int.TryParse(source, out var value))
        {
            value = registers[source[0]];
        }

        registers[reg] = value;
        i++;
    }

    private void Sub(char reg, string source)
    {
        if (source == null) return;

        if (!int.TryParse(source, out var value))
        {
            value = registers[source[0]];
        }

        registers[reg] -= value;
        i++;
    }

    private void Mul(char reg, string source)
    {
        if (source == null) return;

        if (!int.TryParse(source, out var value))
        {
            value = registers[source[0]];
        }

        registers[reg] *= value;
        i++;
    }

    private void Jnz(char reg, string source)
    {
        if (source == null) return;

        if (!int.TryParse(source, out var value))
        {
            value = registers[source[0]];
        }

        var check = reg == '1' ? 1 : registers[reg];
        if (check != 0)
        {
            i += value;
        }
        else
        {
            i++;
        }
    }
}
