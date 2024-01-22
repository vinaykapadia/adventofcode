namespace AdventOfCode._2023.Day14;

[ProblemName("Parabolic Reflector Dish")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        var map = input.Lines().Select(line => line.ToList()).ToList();

        TiltNorth(map);

        return Total(map);
    }

    public object PartTwo(string input)
    {
        // Does not work yet.
        var map = input.Lines().Select(line => line.ToList()).ToList();

        for (var i = 0; i < 1000000000; i++)
        {
            TiltNorth(map);
            TiltWest(map);
            TiltSouth(map);
            TiltEast(map);
        }

        return Total(map);
    }

    private static int Total(List<List<char>> map)
    {
        var total = 0;
        for (var i = 0; i < map.Count; i++)
        {
            for (var j = 0; j < map[i].Count; j++)
            {
                if (map[i][j] == 'O')
                {
                    total += map.Count - i;
                }
            }
        }

        return total;
    }

    private static void TiltNorth(List<List<char>> map)
    {
        for (var i = 1; i < map.Count; i++)
        {
            for (var j = 0; j < map[i].Count; j++)
            {
                if (map[i][j] == 'O')
                {
                    var m = i - 1;
                    while (m >= 0 && map[m][j] == '.')
                    {
                        (map[m][j], map[m + 1][j]) = (map[m + 1][j], map[m][j]);
                        m--;
                    }
                }
            }
        }
    }
    
    private static void TiltWest(List<List<char>> map)
    {
        for (var j = 1; j < map[0].Count; j++)
        {
            for (var i = 0; i < map.Count; i++)
            {
                if (map[i][j] == 'O')
                {
                    var m = j - 1;
                    while (m >= 0 && map[i][m] == '.')
                    {
                        (map[i][m], map[i][m + 1]) = (map[i][m + 1], map[i][m]);
                        m--;
                    }
                }
            }
        }
    }

    private static void TiltSouth(List<List<char>> map)
    {
        for (var i = map.Count - 2; i >= 0; i--)
        {
            for (var j = map[i].Count - 1; j >= 0; j--)
            {
                if (map[i][j] == 'O')
                {
                    var m = i + 1;
                    while (m < map.Count && map[m][j] == '.')
                    {
                        (map[m][j], map[m - 1][j]) = (map[m - 1][j], map[m][j]);
                        m++;
                    }
                }
            }
        }
    }

    private static void TiltEast(List<List<char>> map)
    {
        for (var j = map[0].Count - 2; j >= 0; j--)
        {
            for (var i = map.Count - 1; i >= 0; i--)
            {
                if (map[i][j] == 'O')
                {
                    var m = j + 1;
                    while (m < map.Count && map[i][m] == '.')
                    {
                        (map[i][m], map[i][m - 1]) = (map[i][m - 1], map[i][m]);
                        m++;
                    }
                }
            }
        }
    }
}
