using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Lib;

namespace AdventOfCode._2017.Day25;

[ProblemName("The Halting Problem")]      
internal class Solution : ISolver
{
    // values from input are typed in

    private static readonly AutoAddingDictionary<int, int> Tape = new();
    private static int _pointer = 0;

    public object PartOne(string input)
    {
        Dictionary<char, Func<char>> stateMap = new Dictionary<char, Func<char>>
        {
            {'A', StateA},
            {'B', StateB},
            {'C', StateC},
            {'D', StateD},
            {'E', StateE},
            {'F', StateF}
        };

        char state = 'A';

        for (int steps = 0; steps < 12172063; steps++)
        {
            state = stateMap[state]();
        }

        return Checksum();
    }

    private static int Checksum()
    {
        return Tape.Sum(x => x.Value);
    }

    private static char StateA()
    {
        switch (Tape[_pointer])
        {
            case 0:
                Tape[_pointer] = 1;
                _pointer++;
                return 'B';
            case 1:
                Tape[_pointer] = 0;
                _pointer--;
                return 'C';
            default:
                throw new InvalidOperationException();
        }
    }

    private static char StateB()
    {
        switch (Tape[_pointer])
        {
            case 0:
                Tape[_pointer] = 1;
                _pointer--;
                return 'A';
            case 1:
                Tape[_pointer] = 1;
                _pointer--;
                return 'D';
            default:
                throw new InvalidOperationException();
        }
    }

    private static char StateC()
    {
        switch (Tape[_pointer])
        {
            case 0:
                Tape[_pointer] = 1;
                _pointer++;
                return 'D';
            case 1:
                Tape[_pointer] = 0;
                _pointer++;
                return 'C';
            default:
                throw new InvalidOperationException();
        }
    }

    private static char StateD()
    {
        switch (Tape[_pointer])
        {
            case 0:
                Tape[_pointer] = 0;
                _pointer--;
                return 'B';
            case 1:
                Tape[_pointer] = 0;
                _pointer++;
                return 'E';
            default:
                throw new InvalidOperationException();
        }
    }

    private static char StateE()
    {
        switch (Tape[_pointer])
        {
            case 0:
                Tape[_pointer] = 1;
                _pointer++;
                return 'C';
            case 1:
                Tape[_pointer] = 1;
                _pointer--;
                return 'F';
            default:
                throw new InvalidOperationException();
        }
    }

    private static char StateF()
    {
        switch (Tape[_pointer])
        {
            case 0:
                Tape[_pointer] = 1;
                _pointer--;
                return 'E';
            case 1:
                Tape[_pointer] = 1;
                _pointer++;
                return 'A';
            default:
                throw new InvalidOperationException();
        }
    }
}
