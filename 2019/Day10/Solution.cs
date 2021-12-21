using AdventOfCode.Common.Rational;

namespace AdventOfCode._2019.Day10;

[ProblemName("Monitoring Station")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        var lines = input.Lines();
        int height = lines.Length;
        int width = lines[0].Length;
        int[][] space = new int[height][];
        for (int i = 0; i < lines.Length; i++)
        {
            space[i] = lines[i].Select(x => x == '.' ? 0 : 1).ToArray();
        }

        int max = 0;
        int xCo = -1;
        int yCo = -1;
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (space[i][j] == 1)
                {
                    int c = CheckIt(space, i, j);
                    if (c > max)
                    {
                        max = c;
                        xCo = i;
                        yCo = j;
                    }
                }
            }
        }
        
        return max;
    }

    public object PartTwo(string input)
    {
        return 0;
    }

    private static int CheckIt(int[][] space, int i, int j)
    {
        List<Rational> slopesLeft = new List<Rational>();
        List<Rational> slopesRight = new List<Rational>();

        for (int h = 0; h < space.Length; h++)
        {
            for (int v = 0; v < space[0].Length; v++)
            {
                if (h != i || v != j)
                {
                    if (space[h][v] == 1)
                    {
                        int n = h - i;
                        int d = v - j;
                        if (d == 0)
                        {
                            n = n < 0 ? -999 : 999;
                            d = 1;
                        }
                        if (n == 0)
                        {
                            n = 1;
                            d = d < 0 ? -999 : 999;
                        }
                        Rational r = new Rational(n, d);

                        if (h < i)
                        {
                            if (!slopesLeft.Contains(r)) slopesLeft.Add(r);
                        }
                        else
                        {
                            if (!slopesRight.Contains(r)) slopesRight.Add(r);
                        }
                    }
                }
            }
        }

        return slopesLeft.Count + slopesRight.Count;
    }
}
