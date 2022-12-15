namespace AdventOfCode._2022.Day08;

[ProblemName("Treetop Tree House")]      
internal class Solution : ISolver
{
    public object PartOne(string input)
    {
        var lines = input.Lines();
        var count = 0;

        for (var i = 1; i < lines.Length - 1; i++)
        {
            for (var j = 1; j < lines[i].Length - 1; j++)
            {
                if (IsVisible(lines, i, j))
                {
                    count++;
                }
            }
        }

        return count + (lines.Length * 2) + (lines[0].Length * 2) - 4;
    }

    public object PartTwo(string input)
    {
        var lines = input.Lines();
        var max = 0;

        for (var i = 1; i < lines.Length - 1; i++)
        {
            for (var j = 1; j < lines[i].Length - 1; j++)
            {
                var score = GetScore(lines, i, j);
                if (score > max)
                {
                    max = score;
                }
            }
        }

        return max;
    }

    private static int GetScore(IReadOnlyList<string> lines, int x, int y)
    {
        int scoreUp = 0, scoreDown = 0, scoreLeft = 0, scoreRight = 0;

        bool blocked = false;

        for (var i = x - 1; i >= 0 && !blocked; i--)
        {
            if (lines[i][y] >= lines[x][y])
            {
                blocked = true;
            }

            scoreUp++;
        }

        blocked = false;

        for (var i = x + 1; i < lines.Count && !blocked; i++)
        {
            if (lines[i][y] >= lines[x][y])
            {
                blocked = true;
            }

            scoreDown++;
        }

        blocked = false;

        for (var j = y - 1; j >= 0 && !blocked; j--)
        {
            if (lines[x][j] >= lines[x][y])
            {
                blocked = true;
            }

            scoreLeft++;
        }

        blocked = false;

        for (var j = y + 1; j < lines[0].Length && !blocked; j++)
        {
            if (lines[x][j] >= lines[x][y])
            {
                blocked = true;
            }

            scoreRight++;
        }

        return scoreUp * scoreRight * scoreLeft * scoreDown;
    }

    private static bool IsVisible(IReadOnlyList<string> lines, int x, int y)
    {
        var visible = true;

        for (var i = x - 1; i >= 0; i--)
        {
            if (lines[i][y] >= lines[x][y])
            {
                visible = false;
            }
        }

        if (visible) return true;
        visible = true;

        for (var i = x + 1; i < lines.Count; i++)
        {
            if (lines[i][y] >= lines[x][y])
            {
                visible = false;
            }
        }

        if (visible) return true;
        visible = true;

        for (var j = y - 1; j >= 0; j--)
        {
            if (lines[x][j] >= lines[x][y])
            {
                visible = false;
            }
        }

        if (visible) return true;
        visible = true;

        for (var j = y + 1; j < lines[0].Length; j++)
        {
            if (lines[x][j] >= lines[x][y])
            {
                visible = false;
            }
        }

        return visible;
    }
}
