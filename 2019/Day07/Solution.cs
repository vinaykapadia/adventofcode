using System.Threading;

namespace AdventOfCode._2019.Day07;

[ProblemName("Amplification Circuit")]      
internal class Solution : ISolver
{
    private readonly IntcodeComputer Computer = new();

    public object PartOne(string input)
    {
        var progList = input.Split(',').Select(long.Parse).ToArray();
        long max = 0;

        for (int i = 0; i < 5; i++)
        for (int j = 0; j < 5; j++)
        for (int k = 0; k < 5; k++)
        for (int l = 0; l < 5; l++)
        for (int m = 0; m < 5; m++)
        {
            var d = new AutoAddingDictionary<int, int>();
            d[i]++;
            d[j]++;
            d[k]++;
            d[l]++;
            d[m]++;
            if (d.Count != 5) 
                continue;

            var phases = new[] { i, j, k, l, m };

            Computer.AddInput(phases[0], 0);
            var program = progList.ToArray();
            program = Computer.Process(program);
            var output = Computer.GetOutput();

            Computer.AddInput(phases[1], output);
            program = progList.ToArray();
            program = Computer.Process(program);
            output = Computer.GetOutput();

            Computer.AddInput(phases[2], output);
            program = progList.ToArray();
            program = Computer.Process(program);
            output = Computer.GetOutput();

            Computer.AddInput(phases[3], output);
            program = progList.ToArray();
            program = Computer.Process(program);
            output = Computer.GetOutput();

            Computer.AddInput(phases[4], output);
            program = progList.ToArray();
            program = Computer.Process(program);
            output = Computer.GetOutput();

            if (output > max) max = output;
        }

        return max;
    }

    public object PartTwo(string input)
    {
        var progList = input.Split(',').Select(long.Parse).ToArray();
        long max = 0;
        string finalPhases = "";

        for (int i = 5; i < 10; i++)
        for (int j = 5; j < 10; j++)
        for (int k = 5; k < 10; k++)
        for (int l = 5; l < 10; l++)
        for (int m = 5; m < 10; m++)
        {
            var d = new AutoAddingDictionary<int, int>();
            d[i]++;
            d[j]++;
            d[k]++;
            d[l]++;
            d[m]++;
            if (d.Count != 5) continue;

            long final = 0;

            var AmpA = new IntcodeComputer();
            var AmpB = new IntcodeComputer();
            var AmpC = new IntcodeComputer();
            var AmpD = new IntcodeComputer();
            var AmpE = new IntcodeComputer();

            AmpA.AddInput(i);
            AmpB.AddInput(j);
            AmpC.AddInput(k);
            AmpD.AddInput(l);
            AmpE.AddInput(m);


            var p1 = progList.ToArray();
            var p2 = progList.ToArray();
            var p3 = progList.ToArray();
            var p4 = progList.ToArray();
            var p5 = progList.ToArray();

            var t1 = new Thread(() => AmpA.Process(p1));
            var t2 = new Thread(() => AmpB.Process(p2));
            var t3 = new Thread(() => AmpC.Process(p3));
            var t4 = new Thread(() => AmpD.Process(p4));
            var t5 = new Thread(() => AmpE.Process(p5));

            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
            t5.Start();

            while (!AmpA.IsRunning || !AmpB.IsRunning || !AmpC.IsRunning || !AmpD.IsRunning || !AmpE.IsRunning)
            {
            }

            AmpA.AddInput(0);

            while (AmpA.IsRunning || AmpB.IsRunning || AmpC.IsRunning || AmpD.IsRunning || AmpE.IsRunning)
            {
                if (AmpA.HasOutput)
                {
                    var output = AmpA.GetOutput();
                    AmpB.AddInput(output);
                }

                if (AmpB.HasOutput)
                {
                    var output = AmpB.GetOutput();
                    AmpC.AddInput(output);
                }

                if (AmpC.HasOutput)
                {
                    var output = AmpC.GetOutput();
                    AmpD.AddInput(output);
                }

                if (AmpD.HasOutput)
                {
                    var output = AmpD.GetOutput();
                    AmpE.AddInput(output);
                }

                if (AmpE.HasOutput)
                {
                    var output = AmpE.GetOutput();
                    final = output;
                    AmpA.AddInput(output);
                }
            }

            /*t1.Abort();
            t2.Abort();
            t3.Abort();
            t4.Abort();
            t5.Abort();*/

            if (final >= max)
            {
                max = final;
                finalPhases = $"{i}{j}{k}{l}{m}";
            }
        }

        return max;
    }
}
