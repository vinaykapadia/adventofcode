using System;
using System.Linq;

namespace AdventOfCode._2019.Day01;

[ProblemName("The Tyranny of the Rocket Equation")]      
internal class Solution : ISolver
{

    public object PartOne(string input) => input.Lines().Sum(line => GetFuelA(int.Parse(line)));


    public object PartTwo(string input) => input.Lines().Sum(line => GetFuelB(int.Parse(line)));

    private static int GetFuelA(int mass)
    {
        return int.Parse((Math.Floor(mass / 3.0) - 2).ToString());
    }

    private static int GetFuelB(int mass)
    {
        int fuel = int.Parse((Math.Floor(mass / 3.0) - 2).ToString());

        if (fuel <= 0) return 0;
        return fuel + GetFuelB(fuel);
    }
}
