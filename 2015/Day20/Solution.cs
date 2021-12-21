using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace AdventOfCode._2015.Day20;

[ProblemName("Infinite Elves and Infinite Houses")]      
internal class Solution : ISolver {

    public object PartOne(string input)
    {
        var num = int.Parse(input);
        var presents = 0;
        var house = 1;

        while (presents < num)
        {
            house++;
            var factors = new List<int>();
            for (var factor = 1; factor * factor < house; factor++)
            {
                if (house % factor == 0)
                {
                    if (!factors.Contains(factor)) factors.Add(factor);
                    if (!factors.Contains(house / factor)) factors.Add(house / factor);
                }
            }

            presents = factors.Sum();

            presents *= 10;
        }

        return house;
    }

    public object PartTwo(string input)
    {
        var num = int.Parse(input);
        var presents = 0;
        var house = 1;

        while (presents < num)
        {
            house++;
            var factors = new List<int>();
            for (var factor = 1; factor * factor < house; factor++)
            {
                if (house % factor == 0)
                {
                    if (house <= factor * 50 && !factors.Contains(factor)) factors.Add(factor);
                    if (house <= (house / factor) * 50 && !factors.Contains(house / factor)) factors.Add(house / factor);
                }
            }

            presents = factors.Sum();

            presents *= 11;
        }

        return house;
    }
}
