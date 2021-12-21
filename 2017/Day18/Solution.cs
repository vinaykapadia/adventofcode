using System;
using System.Collections.Generic;
using System.Linq;
using adventofcode.Lib;

namespace AdventOfCode._2017.Day18;

[ProblemName("Duet")]      
internal class Solution : ISolver
{
    private static readonly AutoAddingDictionary<char, long> Registers = new AutoAddingDictionary<char, long>();
    private static long recover = 0;
    private static long pointer = 0;
    private static long sound = 0;

    public object PartOne(string input)
    {
        Registers['z'] = 1;
        var lines = input.Lines();

        while (recover == 0)
        {
            var inst = lines[pointer];
            char reg = inst[4];
            long value = 0;

            if (inst.Length > 5)
            {
                if (!long.TryParse(inst.Substring(6), out value))
                {
                    value = Registers[inst[6]];
                }
            }

            switch (inst[1])
            {
                case 'n': //snd
                    Sound(reg);
                    break;
                case 'e': //set
                    Set(reg, value);
                    break;
                case 'd': //add
                    Add(reg, value);
                    break;
                case 'u': //mul
                    Multiply(reg, value);
                    break;
                case 'o': //mod
                    Modulo(reg, value);
                    break;
                case 'c': //rcv
                    Recover(reg);
                    break;
                case 'g': //jgz
                    Jump(reg, value);
                    break;
                default:
                    throw new InvalidOperationException();
            }

            pointer++;
        }

        return recover;
    }

    public object PartTwo(string input)
    {
        var lines = input.Lines();

        Prog p0 = new Prog(0, lines);
        Prog p1 = new Prog(1, lines);

        bool done = false;
        while (!done)
        {
            p1.Run();
            p0.Run();
            if (Prog.ReceiveQueue.All(x => x.Value.Count == 0)) done = true;
        }

        return p1.Sent;
    }

    private static void Sound(char reg)
    {
        sound = Registers[reg];
    }

    private static void Set(char reg, long value)
    {
        Registers[reg] = value;
    }

    private static void Add(char reg, long value)
    {
        Registers[reg] += value;
    }

    private static void Multiply(char reg, long value)
    {
        Registers[reg] *= value;
    }

    private static void Modulo(char reg, long value)
    {
        Registers[reg] %= value;
    }

    private static void Recover(char reg)
    {
        if (Registers[reg] != 0)
        {
            recover = sound;
        }
    }

    private static void Jump(char reg, long value)
    {
        if (Registers[reg] != 0)
        {
            pointer += value - 1;
        }
    }

    internal class Prog
    {
        private bool _waiting;
        public static readonly Dictionary<int, Queue<long>> ReceiveQueue = new AutoAddingDictionary<int, Queue<long>>();

        private readonly Dictionary<char, long> _registers = new AutoAddingDictionary<char, long>();
        private long _pointer;
        private readonly int _pid;
        private readonly string[] _input;
        public int Sent;

        public Prog(int programId, string[] instructions)
        {
            _pid = programId;
            _registers['1'] = 1;
            _registers['p'] = _pid;
            _input = instructions;
            _waiting = false;
            ReceiveQueue[_pid] = new Queue<long>();
        }

        public void Run()
        {
            _waiting = false;
            while (!_waiting)
            {
                var inst = _input[_pointer];
                char reg = inst[4];
                long value = 0;

                if (inst.Length > 5)
                {
                    if (!long.TryParse(inst.Substring(6), out value))
                    {
                        value = _registers[inst[6]];
                    }
                }

                switch (inst[1])
                {
                    case 'n': //snd
                        Send(reg);
                        break;
                    case 'e': //set
                        Set(reg, value);
                        break;
                    case 'd': //add
                        Add(reg, value);
                        break;
                    case 'u': //mul
                        Multiply(reg, value);
                        break;
                    case 'o': //mod
                        Modulo(reg, value);
                        break;
                    case 'c': //rcv
                        Receive(reg);
                        break;
                    case 'g': //jgz
                        Jump(reg, value);
                        break;
                    default:
                        throw new InvalidOperationException();
                }

                _pointer++;
            }
        }

        private void Send(char reg)
        {
            Sent++;
            foreach (var item in ReceiveQueue)
            {
                if (item.Key != _pid)
                {
                    item.Value.Enqueue(_registers[reg]);
                }
            }
        }

        private void Set(char reg, long value)
        {
            _registers[reg] = value;
        }

        private void Add(char reg, long value)
        {
            _registers[reg] += value;
        }

        private void Multiply(char reg, long value)
        {
            _registers[reg] *= value;
        }

        private void Modulo(char reg, long value)
        {
            _registers[reg] %= value;
        }

        private void Receive(char reg)
        {
            _waiting = true;
            if (ReceiveQueue[_pid].Count > 0)
            {
                _registers[reg] = ReceiveQueue[_pid].Dequeue();
                _waiting = false;
            }
            else
            {
                _pointer--;
            }
        }

        private void Jump(char reg, long value)
        {
            if (_registers[reg] > 0)
            {
                _pointer += value - 1;
            }
        }
    }
}
