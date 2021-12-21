using System.Threading.Tasks;

namespace AdventOfCode._2019.Day16;

[ProblemName("Flawed Frequency Transmission")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        int[] signal = input.Select(x => int.Parse(x.ToString())).ToArray();

        for (int i = 0; i < 100; i++) //phase #
        {
            signal = DoPhase(signal);
        }

        string s = "";
        for (int i = 0; i < 8; i++)
        {
            s += signal[i];
        }

        return s;
    }

    public object PartTwo(string input)
    {
        return 0;

        /*int[] signal = input.Select(x => int.Parse(x.ToString())).ToArray();
        int offset = int.Parse(input.Substring(0, 7));

        int[] realSignal = new int[signal.Length * 10000];

        for (int i = 0; i < realSignal.Length; i++)
        {
            realSignal[i] = signal[i % signal.Length];
        }

        for (int i = 0; i < 100; i++) //phase #
        {
            Console.Write($"Phase {i + 1} ");
            realSignal = DoPhase(realSignal);
            Console.WriteLine();
        }

        var s = "";
        for (int i = 0; i < 8; i++)
        {
            s += signal[offset + i];
        }

        return s;*/
    }

    private static int[] DoPhase(int[] signal)
    {
        int length = signal.Length;
        int[] basePattern = { 0, 1, 0, -1 };
        int[] newSignal = new int[length];
        Parallel.For(0, length, j =>
        {
            int newNumber = 0;
            for (int k = 0; k < length; k++)
            {
                int patternSelection = (k + 1) / (j + 1) % 4;
                newNumber += signal[k] * basePattern[patternSelection];
            }

            newSignal[j] = Math.Abs(newNumber) % 10;
            //if ((j + 1) % (length / 100) == 0)
                //Console.Write(".");
        });

        return newSignal;
    }
}
