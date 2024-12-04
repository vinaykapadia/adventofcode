namespace AdventOfCode._2024.Day04;

[ProblemName("Ceres Search")]      
internal class Solution : ISolver
{

    public object PartOne(string input) => CountXmas(input.Lines(),  1,  0) + // ->
                                           CountXmas(input.Lines(), -1,  0) + // <-
                                           CountXmas(input.Lines(),  0, -1) + // ^
                                           CountXmas(input.Lines(),  0,  1) + // v
                                           CountXmas(input.Lines(),  1, -1) + // -^
                                           CountXmas(input.Lines(),  1,  1) + // -v
                                           CountXmas(input.Lines(), -1, -1) + // ^-
                                           CountXmas(input.Lines(), -1,  1);  // v-

    public object PartTwo(string input)
    {
        var array = input.Lines();
        var count = 0;

        for (var i = 1; i < array.Length - 1; i++)
        {
	        for (var j = 1; j < array[i].Length - 1; j++)
	        {
		        if (array[i][j] == 'A')
		        {
			        if ((array[i - 1][j - 1] == 'M' && array[i + 1][j + 1] == 'S') ||
			            (array[i - 1][j - 1] == 'S' && array[i + 1][j + 1] == 'M'))
			        {
				        if ((array[i - 1][j + 1] == 'M' && array[i + 1][j - 1] == 'S') ||
				            (array[i - 1][j + 1] == 'S' && array[i + 1][j - 1] == 'M'))
				        {
					        count++;
				        }
			        }
				}
	        }
        }

        return count;
    }

    private static int CountXmas(IReadOnlyList<string> array, int hDir, int vDir)
    {
        var count = 0;

        var hStart = hDir == -1 ? 3 : 0;
        var vStart = vDir == -1 ? 3 : 0;
        var hEnd = hDir == 1 ? array[0].Length - 4 : array[0].Length - 1;
        var vEnd = vDir == 1 ? array.Count - 4 : array.Count - 1;
        var hStep = hStart < hEnd ? 1 : -1;
		var vStep = vStart < vEnd ? 1 : -1;	

        for(var h = hStart; h <= hEnd; h += hStep)
		{
			for (var v = vStart; v <= vEnd; v += vStep)
			{
				if (array[h][v] == 'X' &&
                    array[h + hDir][v + vDir] == 'M' &&
                    array[h + hDir * 2][v + vDir * 2] == 'A' &&
                    array[h + hDir * 3][v + vDir * 3] == 'S')
				{
					count++;
				}
			}
		}

		return count;
    }
}
