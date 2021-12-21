namespace AdventOfCode._2019;

public class IntcodeComputer
{
    public static IntcodeComputer Computer = new();

    private readonly long[] _program;
    private long _pointer;
    private long _relativeBase;
    private long _modes;

    private readonly Queue<long> _inputs = new();
    private readonly Queue<long> _outputs = new();

    public IntcodeComputer()
    {
        IsRunning = false;
        IsWaiting = false;
        _program = new long[4096];
        InMode = InOutMode.Memory;
        OutMode = InOutMode.Memory;
    }

    public InOutMode InMode { get; set; }
    public InOutMode OutMode { get; set; }

    public bool IsRunning { get; private set; }

    public bool IsWaiting { get; private set; }

    public long LastOutput { get; private set; }

    public void AddInput(params long[] inputs)
    {
        foreach (var i in inputs)
        {
            _inputs.Enqueue(i);
        }
    }

    public void AddInput(params string[] inputs)
    {
        AddInput(inputs.Select(long.Parse).ToArray());
    }

    public bool HasOutput => _outputs.Count > 0;

    public long GetOutput()
    {
        return _outputs.Dequeue();
    }

    public long[] Process(string program)
    {
        var progList = program.Split(',').Select(long.Parse).ToArray();
        return Process(progList);
    }

    public long[] Process(long[] program)
    {
        InitializeProgram(program);

        long opcode = 0;

        while (opcode != 99)
        {
            opcode = _program[_pointer];
            _modes = opcode / 100;
            opcode %= 100;

            switch (opcode)
            {
                case 1:
                    OpAdd();
                    break;
                case 2:
                    OpMultiply();
                    break;
                case 3:
                    OpInput();
                    break;
                case 4:
                    OpOutput();
                    break;
                case 5:
                    OpJumpTrue();
                    break;
                case 6:
                    OpJumpFalse();
                    break;
                case 7:
                    OpLessThan();
                    break;
                case 8:
                    OpEqual();
                    break;
                case 9:
                    OpAdjustRelativeBase();
                    break;
                case 99: break;
                default: throw new InvalidOperationException();
            }
        }

        IsWaiting = false;
        IsRunning = false;
        return _program;
    }

    private void InitializeProgram(long[] program)
    {
        for (var i = 0; i < program.Length; i++) _program[i] = program[i];

        IsRunning = true;
        _pointer = 0;
        _relativeBase = 0;
    }

    private void OpAdd()
    {
        var mode1 = _modes % 10;
        var mode2 = (_modes / 10) % 10;
        var mode3 = _modes / 100;

        if (mode3 == 1) throw new InvalidOperationException();

        var input1 = _program[_pointer + 1];
        var input2 = _program[_pointer + 2];
        var output = _program[_pointer + 3];

        input1 = CheckMode(input1, mode1);
        input2 = CheckMode(input2, mode2);
        if (mode3 == 2) output = _relativeBase + output;

        _program[output] = input1 + input2;

        _pointer += 4;
    }

    private void OpMultiply()
    {
        var mode1 = _modes % 10;
        var mode2 = (_modes / 10) % 10;
        var mode3 = _modes / 100;

        if (mode3 == 1) throw new InvalidOperationException();

        var input1 = _program[_pointer + 1];
        var input2 = _program[_pointer + 2];
        var output = _program[_pointer + 3];

        input1 = CheckMode(input1, mode1);
        input2 = CheckMode(input2, mode2);
        if (mode3 == 2) output = _relativeBase + output;

        _program[output] = input1 * input2;

        _pointer += 4;
    }

    private void OpInput()
    {
        if (_modes is > 9 or 1) throw new InvalidOperationException();

        var output = _program[_pointer + 1];

        if (_modes == 2) output = _relativeBase + output;

        long input;

        if (InMode == InOutMode.Console)
        {
            Console.Write("Input: ");
            input = int.Parse(Console.ReadLine() ?? "0");
        }
        else
        {
            while (_inputs.Count == 0)
            {
                IsWaiting = true;
            }

            IsWaiting = false;
            input = _inputs.Dequeue();
        }

        _program[output] = input;

        _pointer += 2;
    }

    private void OpOutput()
    {
        if (_modes > 9) throw new InvalidOperationException();

        var input = _program[_pointer + 1];

        input = CheckMode(input, _modes);

        if (OutMode == InOutMode.Console)
        {
            Console.WriteLine(input);
        }
        else
        {
            _outputs.Enqueue(input);
            LastOutput = input;
        }

        _pointer += 2;
    }

    private void OpJumpTrue()
    {
        JumpBool(_modes, true);
    }

    private void OpJumpFalse()
    {
        JumpBool(_modes, false);
    }

    private void OpLessThan()
    {
        var mode1 = _modes % 10;
        var mode2 = (_modes / 10) % 10;
        var mode3 = _modes / 100;

        if (mode3 == 1) throw new InvalidOperationException();

        var input1 = _program[_pointer + 1];
        var input2 = _program[_pointer + 2];
        var output = _program[_pointer + 3];

        input1 = CheckMode(input1, mode1);
        input2 = CheckMode(input2, mode2);
        if (mode3 == 2) output = _relativeBase + output;

        var result = input1 < input2;
        _program[output] = result ? 1 : 0;

        _pointer += 4;
    }

    private void OpEqual()
    {
        var mode1 = _modes % 10;
        var mode2 = (_modes / 10) % 10;
        var mode3 = _modes / 100;

        if (mode3 == 1) throw new InvalidOperationException();

        var input1 = _program[_pointer + 1];
        var input2 = _program[_pointer + 2];
        var output = _program[_pointer + 3];

        input1 = CheckMode(input1, mode1);
        input2 = CheckMode(input2, mode2);
        if (mode3 == 2) output = _relativeBase + output;

        var result = input1 == input2;
        _program[output] = result ? 1 : 0;

        _pointer += 4;
    }

    private void OpAdjustRelativeBase()
    {
        if (_modes > 9) throw new InvalidOperationException();

        var input = _program[_pointer + 1];

        input = CheckMode(input, _modes);

        _relativeBase += input;

        _pointer += 2;
    }

    private void JumpBool(long modes, bool jumpMode)
    {
        if (modes > 99) throw new InvalidOperationException();
        var mode1 = modes % 10;
        var mode2 = modes / 10;

        var input1 = _program[_pointer + 1];
        var input2 = _program[_pointer + 2];

        input1 = CheckMode(input1, mode1);
        input2 = CheckMode(input2, mode2);

        if (input1 == 0 != jumpMode)
        {
            _pointer = input2;
        }
        else
        {
            _pointer += 3;
        }
    }

    private long CheckMode(long parameter, long mode)
    {
        return mode switch
        {
            0 => // Position Mode
                _program[parameter],
            1 => // Immediate Mode
                parameter,
            2 => // Relative Mode
                _program[parameter + _relativeBase],
            _ => throw new InvalidOperationException()
        };
    }

    private string CommandString()
    {
        return "" + _program[_pointer] + ", " + _program[_pointer + 1] + ", " + _program[_pointer + 2] + ", " +
               _program[_pointer + 3];
    }
}

public enum InOutMode
{
    Console,
    Memory
}

public class PointerAttribute : Attribute
{

}