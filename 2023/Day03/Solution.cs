namespace AdventOfCode._2023.Day03;

[ProblemName("Gear Ratios")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        var lines = input.Lines();
        var totalLines = lines.Length;
        var lineLength = lines[0].Length;
        var total = 0;
        var gears = new Dictionary<int, List<int>>();

        for (var i = 0; i < totalLines; i++)
        {
            for (var j = 0; j < lineLength; j++)
            {
                if (lines[i][j] < '0' || lines[i][j] > '9')
                {
                    continue;
                }

                var endOfNum = j;
                while (endOfNum < lineLength && lines[i][endOfNum] >= '0' && lines[i][endOfNum] <= '9')
                {
                    endOfNum++;
                }

                var startVertical = i == 0 ? 0 : i - 1;
                var endVertical = i == totalLines - 1 ? i : i + 1;
                var startHorizontal = j == 0 ? 0 : j - 1;
                var endHorizontal = endOfNum == lineLength ? endOfNum : endOfNum + 1;
                var gearNum = int.Parse(lines[i][j..endOfNum]);
                var found = false;

                for (var u = startVertical; u <= endVertical; u++)
                {
                    for (var v = startHorizontal; v < endHorizontal; v++)
                    {
                        if ((lines[u][v] < '0' || lines[u][v] > '9') && lines[u][v] != '.')
                        {
                            found = true;
                            if (lines[u][v] == '*')
                            {
                                var index = u * 1000 + v;
                                if (!gears.ContainsKey(index))
                                {
                                    gears.Add(index, new List<int>());
                                }
                                gears[index].Add(gearNum);
                            }
                        }
                    }
                }

                if (found)
                {
                    total += int.Parse(lines[i][j..endOfNum]);
                }

                j = endOfNum;
            }
        }

        PartBAnswer = gears.Where(x => x.Value.Count == 2).Sum(x => x.Value[0] * x.Value[1]);
        return total;
    }

    public object PartTwo(string input) => PartBAnswer;
}
