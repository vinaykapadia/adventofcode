using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2015.Day16;

[ProblemName("Aunt Sue")]
internal class Solution : ISolver {
    private readonly List<Aunt> _aunts = new();

    public object PartOne(string input) {

        var num = 1;
        foreach (var line in input.Lines())
        {
            Aunt aunt = new Aunt { number = num };
            string[] items = line[(line.IndexOf(':') + 2)..].Replace(" ", "").Split(',');
            foreach (var item in items)
            {
                int count = int.Parse(item[(item.IndexOf(':') + 1)..]);
                if (item.StartsWith("children")) aunt.children = count;
                else if (item.StartsWith("cats")) aunt.cats = count;
                else if (item.StartsWith("samoyeds")) aunt.samoyeds = count;
                else if (item.StartsWith("pomeranians")) aunt.pomeranians = count;
                else if (item.StartsWith("akitas")) aunt.akitas = count;
                else if (item.StartsWith("vizslas")) aunt.vizslas = count;
                else if (item.StartsWith("goldfish")) aunt.goldfish = count;
                else if (item.StartsWith("trees")) aunt.trees = count;
                else if (item.StartsWith("cars")) aunt.cars = count;
                else if (item.StartsWith("perfumes")) aunt.perfumes = count;
                else throw new Exception();
            }
            _aunts.Add(aunt);
            num++;
        }

        return _aunts.First(a =>
            a.children is null or 3 &&
            a.cats is null or 7 &&
            a.samoyeds is null or 2 &&
            a.pomeranians is null or 3 &&
            a.akitas is null or 0 &&
            a.vizslas is null or 0 &&
            a.goldfish is null or 5 &&
            a.trees is null or 3 &&
            a.cars is null or 2 &&
            a.perfumes is null or 1).number;
    }

    public object PartTwo(string input) {
        return _aunts.First(a =>
            a.children is null or 3 &&
            a.cats is null or > 7 &&
            a.samoyeds is null or 2 &&
            a.pomeranians is null or < 3 &&
            a.akitas is null or 0 &&
            a.vizslas is null or 0 &&
            a.goldfish is null or < 5 &&
            a.trees is null or > 3 &&
            a.cars is null or 2 &&
            a.perfumes is null or 1).number;
    }

    class Aunt
    {
        public int number;
        public int? children;
        public int? cats;
        public int? samoyeds;
        public int? pomeranians;
        public int? akitas;
        public int? vizslas;
        public int? goldfish;
        public int? trees;
        public int? cars;
        public int? perfumes;
    }
}
