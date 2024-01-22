using System.Text;
using System.Text.RegularExpressions;
using File = System.IO.File;

namespace AdventOfCode._2023.Day08;

[ProblemName("Haunted Wasteland")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        var lines = input.Lines();
        var order = lines[0];
        Dictionary<string, (string Left, string Right)> map = lines.Skip(2).Select(line => Regex.Matches(line, "\\w+")).ToDictionary(matches => matches[0].Value, matches => (matches[1].Value, matches[2].Value));
        var steps = 0;
        var currentNode = "AAA";

        while (currentNode != "ZZZ")
        {
            currentNode = order[steps % order.Length] == 'L' ? map[currentNode].Left : map[currentNode].Right;
            steps++;
        }

        return steps;
    }

    public object PartTwo(string input)
    {
        var lines = input.Lines();
        var order = lines[0];
        Dictionary<string, (string Left, string Right)> map = lines.Skip(2).Select(line => Regex.Matches(line, "\\w+")).ToDictionary(matches => matches[0].Value, matches => (matches[1].Value, matches[2].Value));


        /* For normal run, use these values.*/
        long steps = 0;
        var currentNode = map.Keys.Where(x => x[2] == 'A').ToList();

        /* To load save state, enter values here.*/
        /*var steps = 12315700000000;
        var currentNode = new List<string>
        {
            "FSP",
            "BDM",
            "HGX",
            "NBS",
            "RHB",
            "RPG"
        };*/

        while (currentNode.Any(x => x[2] != 'Z'))
        {
            for (var i = 0; i < currentNode.Count; i++)
            {
                currentNode[i] = order[(int)(steps % order.Length)] == 'L' ? map[currentNode[i]].Left : map[currentNode[i]].Right;
            }
            steps++;
            if (steps % 100000000 == 0)
            {
                Console.WriteLine(steps / 1000000000.0 + "B");
                StringBuilder sb = new StringBuilder();
                foreach (var node in currentNode)
                {
                    sb.AppendLine($"\"{node}\",");
                }

                sb.AppendLine(steps.ToString());
                File.WriteAllText("savestate.txt", sb.ToString());
            }
        }

        return steps;
    }
}
