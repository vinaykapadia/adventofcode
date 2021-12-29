namespace AdventOfCode._2021.Day07;

[ProblemName("The Treachery of Whales")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        var crabs = input.Nums();

        var minFuel = int.MaxValue;
        for (var i = crabs.Min(); i <= crabs.Max(); i++)
        {
            var fuel = crabs.Sum(x => Math.Abs(i - x));
            if (fuel < minFuel) minFuel = fuel;
        }

        return minFuel;
    }

    public object PartTwo(string input)
    {
        var crabs = input.Nums();

        var minFuel = int.MaxValue;
        for (var i = crabs.Min(); i <= crabs.Max(); i++)
        {
            var fuel = crabs.Sum(x =>
            {
                var dist = Math.Abs(i - x);
                return dist * (dist + 1) / 2;
            });
            if (fuel < minFuel) minFuel = fuel;
        }

        return minFuel;
    }
}
