using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode._2015.Day14;

[ProblemName("Reindeer Olympics")]      
internal class Solution : ISolver {

    public static int PartBAnswer { get; set; }

    public object PartOne(string input) {

        const int seconds = 2503;

        var deers = (from line in input.Lines()
        let regex = new Regex(@"\d+")
        let matches = regex.Matches(line)
        let name = line[..line.IndexOf(' ')]
        let speed = int.Parse(matches[0].ToString())
        let flyTime = int.Parse(matches[1].ToString())
        let restTime = int.Parse(matches[2].ToString())
        select new Reindeer
        {
            Name = name, Speed = speed, FlyTime = flyTime, RestTime = restTime,
        }).ToList();

        for (var i = 1; i <= seconds; i++)
        {
            foreach (var deer in deers)
            {
                Tick(deer);
            }

            var max = deers.Max(x => x.Distance);
            foreach (var deer in deers.Where(deer => deer.Distance == max))
            {
                deer.Score++;
            }
        }

        PartBAnswer = deers.Max(x => x.Score);
        return deers.Max(x => x.Distance);
    }

    public object PartTwo(string input) {
        return PartBAnswer;
    }

    private static void Tick(Reindeer deer)
    {
        deer.CurrentStateTime++;
        if (deer.Resting)
        {
            if (deer.CurrentStateTime == deer.RestTime)
            {
                deer.CurrentStateTime = 0;
                deer.Resting = false;
            }
        }
        else
        {
            deer.Distance += deer.Speed;
            if (deer.CurrentStateTime == deer.FlyTime)
            {
                deer.CurrentStateTime = 0;
                deer.Resting = true;
            }
        }
    }

    class Reindeer
    {
        public string Name;
        public int Speed;
        public int FlyTime;
        public int RestTime;
        public int Distance = 0;
        public int Score = 0;
        public bool Resting = false;
        public int CurrentStateTime = 0;
    }
}
