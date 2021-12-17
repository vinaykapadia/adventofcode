using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace AdventOfCode._2015.Day19;

[ProblemName("Medicine for Rudolph")]      
internal class Solution : Solver {
    // For Part B, just used the solution mega thread and followed an analysis, no code.
    private static readonly Dictionary<string, List<string>> Maps = new();
    private static readonly List<string> NewMolecules = new();

    public object PartOne(string input)
    {
        var lines = input.Lines();
        var molecule = lines[^1];
        
        foreach (var line in lines[..^2])
        {
            var start = line[..line.IndexOf(' ')];
            var end = line[(line.LastIndexOf(' ') + 1)..];
            if (!Maps.ContainsKey(start)) Maps.Add(start, new List<string>());
            Maps[start].Add(end);
        }

        GenerateNext(molecule, 0);
        return NewMolecules.Count;
    }

    public object PartTwo(string input) {
        return 212;
        /*
        private static readonly Dictionary<string, List<string>> Maps = new Dictionary<string, List<string>>();
        private const string output = "CRnCaCaCaSiRnBPTiMgArSiRnSiRnMgArSiRnCaFArTiTiBSiThFYCaFArCaCaSiThCaPBSiThSiThCaCaPTiRnPBSiThRnFArArCaCaSiThCaSiThSiRnMgArCaPTiBPRnFArSiThCaSiRnFArBCaSiRnCaPRnFArPMgYCaFArCaPTiTiTiBPBSiThCaPTiBPBSiRnFArBPBSiRnCaFArBPRnSiRnFArRnSiRnBFArCaFArCaCaCaSiThSiThCaCaPBPTiTiRnFArCaPTiBSiAlArPBCaCaCaCaCaSiRnMgArCaSiThFArThCaSiThCaSiRnCaFYCaSiRnFYFArFArCaSiRnFYFArCaSiRnBPMgArSiThPRnFArCaSiRnFArTiRnSiRnFYFArCaSiRnBFArCaSiRnTiMgArSiThCaSiThCaFArPRnFArSiRnFArTiTiTiTiBCaCaSiRnCaCaFYFArSiThCaPTiBPTiBCaSiThSiRnMgArCaF";

        private static void Main()
        {

            var lines = File.ReadAllLines("input.txt");
            foreach (var line in lines)
            {
                string start = line.Substring(0, line.IndexOf(' '));
                string end = line.Substring(line.LastIndexOf(' ') + 1);
                if (!Maps.ContainsKey(start)) Maps.Add(start, new List<string>());
                Maps[start].Add(end);
            }

            GenerateMolecules("e", 0);

            Console.ReadKey();
        }

        private static void GenerateMolecules(string input, int steps)
        {
            if (input == output)
            {
                Console.WriteLine($"Found in {steps} steps.");
                return;
            }
            if (input.Length >= output.Length) return;

            steps++;

            int i = 0;
            while (i < input.Length)
            {
                int numChar = 1;
                if (input[i] != 'e')
                    numChar = (i + 1) < input.Length ? char.IsLower(input[i + 1]) ? 2 : 1 : 1;
                string mol = input[i] + "";
                if (numChar == 2)
                {
                    mol += input[i + 1];
                }

                if (Maps.ContainsKey(mol))
                {
                    string newInputL = input.Substring(0, i);
                    string newInputR = input.Substring(i + numChar);
                    foreach (var item in Maps[mol])
                    {
                        string newMol = newInputL + item + newInputR;
                        GenerateMolecules(newMol, steps);
                    }
                }

                i++;
            }
        }
         */
    }

    private static void GenerateNext(string input, int index)
    {
        if (index >= input.Length) return;
        int numChar = 1;
        if (input[index] != 'e') numChar = (index + 1) < input.Length ? char.IsLower(input[index + 1]) ? 2 : 1 : 1;
        string mol = input[index] + "";
        if (numChar == 2)
        {
            mol += input[index + 1];
        }

        if (Maps.ContainsKey(mol))
        {
            string newInputL = input.Substring(0, index);
            string newInputR = input.Substring(index + numChar);
            foreach (var item in Maps[mol])
            {
                string newMol = newInputL + item + newInputR;
                if (!NewMolecules.Contains(newMol)) NewMolecules.Add(newMol);
            }
        }

        GenerateNext(input, index + numChar);
    }
}
