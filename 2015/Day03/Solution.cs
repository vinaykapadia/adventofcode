using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;
using System.Text;

namespace AdventOfCode._2015.Day03;

[ProblemName("Perfectly Spherical Houses in a Vacuum")]      
internal class Solution : Solver
{
    public object PartOne(string input)
    {
        var houses = new List<string>();
        var row = 0;
        var col = 0;
        houses.Add("0-0");

        foreach (var dir in input)
        {
            switch (dir)
            {
                case '^': row++;
                    break;
                case 'v': row--;
                    break;
                case '>': col++;
                    break;
                case '<': col--;
                    break;
            }

            var house = row + "-" + col;
            if (!houses.Contains(house))
            {
                houses.Add(house);
            }
        }

        return houses.Count;
    }

    public object PartTwo(string input) {
        var houses = new List<string>();
        var row = 0;
        var rRow=0;
        var col = 0;
        var rCol = 0;
        houses.Add("0-0");

        for (var i = 0; i < input.Length; i++)
        {
            switch (input[i])
            {
                case '^':
                    row++;
                    break;
                case 'v':
                    row--;
                    break;
                case '>':
                    col++;
                    break;
                case '<':
                    col--;
                    break;
            }

            var house = row + "-" + col;
            if (!houses.Contains(house))
            {
                houses.Add(house);
            }

            i++;

            switch (input[i])
            {
                case '^':
                    rRow++;
                    break;
                case 'v':
                    rRow--;
                    break;
                case '>':
                    rCol++;
                    break;
                case '<':
                    rCol--;
                    break;
            }

            house = rRow + "-" + rCol;
            if (!houses.Contains(house))
            {
                houses.Add(house);
            }
        }

        return houses.Count;
    }
}
