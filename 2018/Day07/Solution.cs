using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AdventOfCode._2018.Day07;

[ProblemName("The Sum of Its Parts")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        AutoAddingDictionary<char, List<char>> steps = new ();
        foreach (var line in input.Lines())
        {
            var preReq = line[5];
            if (!steps.ContainsKey(preReq)) steps.Add(preReq, new List<char>());
            var step = line[36];
            steps[step].Add(preReq);
        }
        
        var sb = new StringBuilder();
        while (steps.Count > 0)
        {
            var readyStep = steps.Where(x => x.Value.Count == 0)
                .OrderBy(x => x.Key).First().Key;
            foreach (var step in steps.Where(x => x.Value.Contains(readyStep)))
            {
                step.Value.Remove(readyStep);
            }

            sb.Append(readyStep);
            steps.Remove(readyStep);
        }

        return sb.ToString();
    }

    public object PartTwo(string input)
    {
        AutoAddingDictionary<char, Step> steps = new();
        foreach (var line in input.Lines())
        {
            var preReq = line[5];
            if (!steps.ContainsKey(preReq)) steps.Add(preReq, new Step{Time = preReq - 4});
            var step = line[36];
            steps[step].PreReq.Add(preReq);
            steps[step].Time = step - 4;
        }

        var workers = new char[5];
        var seconds = 0;

        while (steps.Count > 0)
        {
            seconds++;
            var runSteps = steps.Where(x => x.Value.PreReq.Count == 0).OrderBy(x => x.Key).Take(5);
            foreach (var (key, value) in runSteps)
            {
                value.Time--;
                if (value.Time == 0)
                {
                    foreach (var step in steps.Where(step => step.Value.PreReq.Contains(key)))
                    {
                        step.Value.PreReq.Remove(key);
                    }

                    steps.Remove(key);
                }
            }
        }

        return seconds;
    }

    private class Step
    {
        public readonly List<char> PreReq = new ();
        public int Time;
    }
}
