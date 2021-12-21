using System.Collections.Generic;
using System.Linq;
using adventofcode.Lib;

namespace AdventOfCode._2016.Day10;

[ProblemName("Balance Bots")]      
internal class Solution : ISolver
{
    private static readonly AutoAddingDictionary<int, Bot> Bots = new AutoAddingDictionary<int, Bot>();
    private static readonly AutoAddingDictionary<int, int> Outputs = new AutoAddingDictionary<int, int>();

    public static int PartAAnswer { get; set; }
    public static int PartBAnswer { get; set; }

    public object PartOne(string input)
    {
        var lines = input.Lines().ToList();
        while (lines.Count > 0)
        {
            int i = 0;
            while (i < lines.Count)
            {
                if (lines[i].StartsWith("value"))
                {
                    SetBot(lines[i]);
                    lines.RemoveAt(i);
                }
                else
                {
                    if (MoveChips(lines[i]))
                    {
                        lines.RemoveAt(i);
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }

        PartBAnswer = Outputs[0] * Outputs[1] * Outputs[2];
        return PartAAnswer;
    }

    public object PartTwo(string input)
    {
        return PartBAnswer;
    }

    private static bool MoveChips(string line)
    {
        line = line.Substring(4);
        string num = line.Substring(0, line.IndexOf(' '));
        int from = int.Parse(num);

        if (!Bots[from].Ready()) return false;

        if (Bots[from].ChipLow == 17 && Bots[from].ChipHigh == 61)
        {
            PartAAnswer = from;
        }

        line = line.Substring(num.Length + 14);
        var lowIsBot = line[0] == 'b';
        line = line.Substring(line.IndexOf(' ') + 1);
        num = line.Substring(0, line.IndexOf(' '));
        int lowTo = int.Parse(num);
        line = line.Substring(num.Length + 13);
        var highIsBot = line[0] == 'b';
        line = line.Substring(line.IndexOf(' ') + 1);
        int highTo = int.Parse(line);

        if (lowIsBot)
        {
            Bots[lowTo].AddChip(Bots[from].ChipLow);
        }
        else
        {
            Outputs[lowTo] = Bots[from].ChipLow;
        }

        if (highIsBot)
        {
            Bots[highTo].AddChip(Bots[from].ChipHigh);
        }
        else
        {
            Outputs[highTo] = Bots[from].ChipHigh;
        }

        return true;
    }

    private static void SetBot(string line)
    {
        line = line.Substring(6);
        string num1 = line.Substring(0, line.IndexOf(' '));
        int value = int.Parse(num1);
        line = line.Substring(num1.Length + 13);
        int bot = int.Parse(line);
        Bots[bot].AddChip(value);
    }

    private class Bot
    {
        public int ChipLow, ChipHigh;

        public bool Ready()
        {
            return ChipLow > 0 && ChipHigh > 0;
        }

        public void AddChip(int value)
        {
            if (ChipLow == 0) ChipLow = value;
            else if (ChipLow < value)
                ChipHigh = value;
            else
            {
                ChipHigh = ChipLow;
                ChipLow = value;
            }
        }
    }
}
