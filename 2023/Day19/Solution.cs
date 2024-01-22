namespace AdventOfCode._2023.Day19;

[ProblemName("Aplenty")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        var workflows = new Dictionary<string, Workflow>();
        var parts = new List<Dictionary<char, int>>();

        var lines = input.Lines();
        var i = 0;

        while (lines[i] != "")
        {
            var semicolon = lines[i].IndexOf('{');
            var name = lines[i][..semicolon];
            var steps = lines[i][(semicolon + 1)..^1].Split(',');

            var workflow = new Workflow
            {
                Final = steps[^1]
            };

            for (var j = 0; j < steps.Length - 1; j++)
            {
                var endBit = steps[j][2..].Split(':');
                workflow.Steps.Add(new Step
                {
                    Category = steps[j][0],
                    IsLessThan = steps[j][1] == '<',
                    Value = int.Parse(endBit[0]),
                    Destination = endBit[1]
                });
            }

            workflows.Add(name, workflow);
            i++;
        }

        i++;

        while (i < lines.Length)
        {
            var categories = lines[i][1..^1].Split(',');
            parts.Add(categories.ToDictionary(category => category[0], category => int.Parse(category[2..])));
            i++;
        }

        var total = 0;

        foreach (var part in parts)
        {
            var workflowId = "in";

            var done = false;
            while (!done)
            {
                var workflow = workflows[workflowId];
                workflowId = "";
                for (i = 0; workflowId == ""; i++)
                {
                    var step = workflow.Steps[i];
                    var partValue = part[step.Category];
                    if (step.IsLessThan ? partValue < step.Value : partValue > step.Value)
                    {
                        workflowId = step.Destination;
                    }
                    else if (i == workflow.Steps.Count - 1)
                    {
                        workflowId = workflow.Final;
                    }

                    switch (workflowId)
                    {
                        case "A":
                            total += part.Values.Sum();
                            done = true;
                            break;
                        case "R":
                            done = true;
                            break;
                    }
                }
            }
        }

        return total;
    }

    public object PartTwo(string input)
    {
        return 0;
    }

    private class Step
    {
        public char Category { get; set; }

        public bool IsLessThan { get; set; }

        public int Value { get; set; }

        public string Destination { get; set; }
    }

    private class Workflow
    {
        public IList<Step> Steps { get; set; } = new List<Step>();

        public string Final { get; set; }
    }
}
