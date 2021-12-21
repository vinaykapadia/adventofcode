using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode._2017.Day20;

[ProblemName("Particle Swarm")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        foreach (var line in input.Lines())
        {
            var coords = Regex.Matches(line, "[-]?\\d+").Select(x => int.Parse(x.Value)).ToArray();
            if (coords.Length != 9) throw new Exception();
            var p = new Particle
            {
                Position = (coords[0], coords[1], coords[2]),
                Velocity = (coords[3], coords[4], coords[5]),
                Accelleration = (coords[6], coords[7], coords[8])
            };
        }



        return 0;
    }

    public object PartTwo(string input)
    {
        return 0;
    }

    class Particle
    {
        public (int x, int y, int z) Position;
        public (int x, int y, int z) Velocity;
        public (int x, int y, int z) Accelleration;
    }
}
