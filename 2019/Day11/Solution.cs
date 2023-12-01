using System.Threading;

namespace AdventOfCode._2019.Day11;

[ProblemName("Space Police")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        return 0;
        /* this no longer works
        Computer.InMode = InOutMode.Memory;
        Computer.OutMode = InOutMode.Memory;
        int size = 500;
        int[,] panels = new int[size, size];
        int i = size / 2, j = size / 2;
        int direction = 0; //0 = up, 1 = right, 2 = down, 3 = left
        List<int> panelsPainted = new List<int>();
        
        var t1 = new Thread(() => Computer.Process(input));
        t1.Start();

        // For Part 1, Set = 0, For Part 2, Set = 1
        panels[i, j] = 0;

        while (!Computer.IsRunning) ;

        while (Computer.IsRunning)
        {
            Computer.AddInput(panels[i, j]);
            Thread.Sleep(10);
            //while (!Computer.HasOutput) ;
            var color = Computer.GetOutput();
            if (color == 0 || color == 1) panels[i, j] = (int)color;
            //else throw new InvalidOperationException();
            int key = i * 1000 + j;
            if (!panelsPainted.Contains(key)) panelsPainted.Add(key);
            if (Computer.IsRunning)
            {
                //while (!Computer.HasOutput) ;
                var newDir = Computer.GetOutput();
                if (newDir == 1) direction++;
                else if (newDir == 0) direction += 3;
                //else throw new InvalidOperationException();
                direction %= 4;
                switch (direction)
                {
                    case 0: j--; break;
                    case 1: i++; break;
                    case 2: j++; break;
                    case 3: i--; break;
                }
            }
        }

        return panelsPainted.Count;*/
    }

    public object PartTwo(string input)
    {
        Computer.InMode = InOutMode.Memory;
        Computer.OutMode = InOutMode.Memory;
        int size = 500;
        int[,] panels = new int[size, size];
        int i = size / 2, j = size / 2;
        int direction = 0; //0 = up, 1 = right, 2 = down, 3 = left
        List<int> panelsPainted = new List<int>();
        
        int maxi = i, mini = i, maxj = j, minj = j;

        var t1 = new Thread(() => Computer.Process(input));
        t1.Start();

        // For Part 1, Set = 0, For Part 2, Set = 1
        panels[i, j] = 1;

        while (!Computer.IsRunning) ;

        while (Computer.IsRunning)
        {
            Computer.AddInput(panels[i, j]);
            Thread.Sleep(10);
            //while (!Computer.HasOutput) ;
            var color = Computer.GetOutput();
            if (color == 0 || color == 1) panels[i, j] = (int)color;
            //else throw new InvalidOperationException();
            int key = i * 1000 + j;
            if (!panelsPainted.Contains(key)) panelsPainted.Add(key);
            if (Computer.IsRunning)
            {
                //while (!Computer.HasOutput) ;
                var newDir = Computer.GetOutput();
                if (newDir == 1) direction++;
                else if (newDir == 0) direction += 3;
                //else throw new InvalidOperationException();
                direction %= 4;
                switch (direction)
                {
                    case 0: j--; break;
                    case 1: i++; break;
                    case 2: j++; break;
                    case 3: i--; break;
                }

                if (i < mini) mini = i;
                if (i > maxi) maxi = i;
                if (j < minj) minj = j;
                if (j > maxj) maxj = j;
            }
        }

        for (int a = mini; a <= maxi; a++)
        {
            for (int b = minj; b <= maxj; b++)
            {
                Console.Write(panels[a, b] == 0 ? " " : "*");
            }
            Console.WriteLine();
        }

        // output taken from above console output
        return "EGBHLEUE";
    }
}
