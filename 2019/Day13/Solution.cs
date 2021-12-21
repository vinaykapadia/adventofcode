namespace AdventOfCode._2019.Day13;

[ProblemName("Care Package")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        int[,] screen = new int[100, 100];

        Computer.Process(input);

        while (Computer.HasOutput)
        {
            int x = (int)Computer.GetOutput();
            int y = (int)Computer.GetOutput();
            int tile = (int)Computer.GetOutput();
            screen[x, y] = tile;
            /*Console.CursorLeft = x;
            Console.CursorTop = y;
            Console.Write(tile switch
            {
                0 => ' ',
                1 => '█',
                2 => '≡',
                3 => '_',
                4 => '*',
                _ => ' '
            });*/
        }

        return screen.Cast<int>().Count(i => i == 2);
    }

    public object PartTwo(string input)
    {
        return 0;
    }
}
