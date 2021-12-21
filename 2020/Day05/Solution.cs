namespace AdventOfCode._2020.Day05;

[ProblemName("Binary Boarding")]      
internal class Solution : ISolver
{
    private List<int> ids = new();

    public object PartOne(string input)
    {
        ids = (from line in input.Lines()
            select line.Replace('F', '0').Replace('B', '1').Replace('L', '0').Replace('R', '1')
            into binary
            let row = Convert.ToInt32(binary[..7], 2)
            let seat = Convert.ToInt32(binary[7..], 2)
            select row * 8 + seat).OrderBy(x => x).ToList();

        return ids.Max();
    }

    public object PartTwo(string input)
    {
        for (var i = 0; i < ids.Count - 2; i++)
        {
            if (ids[i] + 2 == ids[i + 1])
            {
                return ids[i] + 1;
            }
        }

        return 0;
    }
}
