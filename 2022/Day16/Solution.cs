namespace AdventOfCode._2022.Day16;

[ProblemName("Proboscidea Volcanium")]      
internal class Solution : ISolver
{

    // 850 too low
    public object PartOne(string input)
    {
        AutoAddingDictionary<string, Valve> valves = new();

        foreach (var line in input.Lines())
        {
            var name = line[6..8];
            var semicolon = line.IndexOf(';');
            var flow = int.Parse(line[23..semicolon]);
            var restOfLine = line[(semicolon + 22)..];
            var space = restOfLine.IndexOf(' ') + 1;
            var tunnels = restOfLine[space..].Split(", ");
            valves.Add(name, new Valve
            {
                FlowRate = flow,
                Tunnels = tunnels.ToList()
            });
        }

        return Step(valves, "AA", 30, 0, 0, "AA " );
    }

    private int Step(IDictionary<string, Valve> valves, string currentValve, int timeLeft, int currentPressure, int ppm, string path)
    {
        Console.WriteLine(path);
        if (timeLeft == 0)
            return currentPressure;

        int stepMax = 0;
        var current = valves[currentValve];

        foreach(var valve in current.Tunnels)
        {
            if (!path.Contains(valve + " "))
            {
                var next = Step(valves, valve, timeLeft - 1, currentPressure + ppm, ppm, path + valve + " ");
                if (next > stepMax) stepMax = next;
            }
        }

        timeLeft--;
        ppm += current.FlowRate;

        if (timeLeft == 0)
            return currentPressure + ppm;

        foreach (var valve in current.Tunnels)
        {
            var next = Step(valves, valve, timeLeft - 1, currentPressure + current.FlowRate + ppm, ppm, path + valve + " ");
            if (next > stepMax) stepMax = next;
        }

        return currentPressure + stepMax;
    }

    public object PartTwo(string input)
    {
        return 0;
    }
}

internal class Valve
{
    public int FlowRate { get; set; }
    public List<string> Tunnels { get; set; }
}