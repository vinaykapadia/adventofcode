using System.Collections.Generic;

namespace AdventOfCode._2015.Day07;

[ProblemName("Some Assembly Required")]      
internal class Solution : Solver { 
    private static readonly Dictionary<string, string> Commands = new();
    private static readonly Dictionary<string, ushort> Wires = new();

    public static ushort PartOneAnswer { get; set; }

    public object PartOne(string input) {
        foreach (var line in input.Split('\n'))
        {
            var wire = line[(line.IndexOf(" -> ") + 4)..];
            var command = line[..line.IndexOf(" -> ")];
            Commands.Add(wire, command);
        }

        PartOneAnswer = Process("a");
        return PartOneAnswer;
    }

    public object PartTwo(string input)
    {
        Wires.Clear();
        Wires.Add("b", PartOneAnswer);
        return Process("a");
    }

    private static ushort Process(string wire)
    {
        if (Wires.ContainsKey(wire)) return Wires[wire];
        var command = Commands[wire];

        ushort value;
        if (command.Contains("AND")) value = And(command);
        else if (command.Contains("OR")) value = Or(command);
        else if (command.Contains("NOT")) value = Not(command);
        else if (command.Contains("RSHIFT")) value = RShift(command);
        else if (command.Contains("LSHIFT")) value = LShift(command);
        else value = Set(command);
        Wires.Add(wire, value);
        return value;
    }

    private static ushort Set(string ins)
    {
        if (!ushort.TryParse(ins, out ushort value))
        {
            value = Process(ins);
        }

        return value;
    }

    private static ushort And(string ins)
    {
        var i1 = ins.IndexOf(" AND ");
        var i2 = i1 + 5;
        var input1 = ins[..i1];

        var input2 = ins[i2..];
        if (!ushort.TryParse(input1, out var val1))
        {
            val1 = Process(input1);
        }

        if (!ushort.TryParse(input2, out var val2))
        {
            val2 = Process(input2);
        }

        var valO = (ushort)(val1 & val2);
        return valO;
    }

    private static ushort Or(string ins)
    {
        var i1 = ins.IndexOf(" OR ");
        var i2 = i1 + 4;
        var input1 = ins[..i1];

        var input2 = ins[i2..];
        if (!ushort.TryParse(input1, out var val1))
        {
            val1 = Process(input1);
        }

        if (!ushort.TryParse(input2, out var val2))
        {
            val2 = Process(input2);
        }

        var valO = (ushort)(val1 | val2);
        return valO;
    }

    private static ushort Not(string ins)
    {
        var input = ins[4..];
        if (!ushort.TryParse(input, out var valI))
        {
            valI = Process(input);
        }

        var valO = unchecked((ushort)(~valI));
        return valO;
    }

    private static ushort RShift(string ins)
    {
        var i = ins.IndexOf(" RSHIFT ");
        var input = ins[..i];

        var shift = ins[(i + 8)..];
        if (!ushort.TryParse(input, out var valI))
        {
            valI = Process(input);
        }

        var valS = ushort.Parse(shift);

        var valO = (ushort)(valI >> valS);
        return valO;
    }

    private static ushort LShift(string ins)
    {
        var i = ins.IndexOf(" LSHIFT ");
        var input = ins[..i];

        var shift = ins[(i + 8)..];
        if (!ushort.TryParse(input, out var valI))
        {
            valI = Process(input);
        }

        var valS = ushort.Parse(shift);

        var valO = (ushort)(valI << valS);
        return valO;
    }
}
