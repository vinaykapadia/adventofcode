using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common.Tree;

namespace AdventOfCode._2017.Day07;

[ProblemName("Recursive Circus")]      
internal class Solution : ISolver
{
    public static int PartBAnswer { get; set; }

    public object PartOne(string input)
    {
        var programs = (from line in input.Lines()
            let name = line[..line.IndexOf(' ')]
            let weight = int.Parse(line.Substring(line.IndexOf('(') + 1, line.IndexOf(')') - line.IndexOf('(') - 1))
            let holds = line.Contains('-') ? line[(line.IndexOf('-') + 3)..].Split(',').Select(x => x.Trim()) : new List<string>()
            select new Prog { Name = name, Weight = weight, Holds = holds.ToList() }).ToList();
        
        Prog head = new Prog();
        foreach (var prog in programs)
        {
            if (!programs.Any(x => x.Holds.Contains(prog.Name)))
            {
                head = prog;
            }

            if (programs.Any(x => x.Holds.Contains("(")))
            {
                throw new InvalidOperationException();
            }
        }

        programs.Remove(head);

        TreeNode<Prog> tree = new TreeNode<Prog>(head);

        BuildTree(tree, programs);

        var off = tree;
        var found = false;
        var weights = off.GetChildren().Select(GetWeight).ToList();
        var single = weights.First(weight => weights.Count(x => x == weight) == 1);
        var multiple = weights.First(weight => weight != single);
        var difference = multiple - single;

        while (!found)
        {
            var index = weights.IndexOf(single);
            off = off.GetChild(index);
            weights = off.GetChildren().Select(GetWeight).ToList();
            single = weights.FirstOrDefault(weight => weights.Count(x => x == weight) == 1);
            if (single == 0)
            {
                found = true;
            }
        }

        PartBAnswer = off.Data.Weight + difference;
        
        return head.Name;
    }

    public object PartTwo(string input)
    {
        return PartBAnswer;
    }

    private static int GetWeight(TreeNode<Prog> tree)
    {
        return tree.Data.Weight + tree.GetChildren().Sum(GetWeight);
    }

    private static void BuildTree(TreeNode<Prog> tree, List<Prog> programs)
    {
        foreach (var item in tree.Data.Holds)
        {
            var prog = programs.First(x => x.Name == item);
            var node = new TreeNode<Prog>(prog);
            tree.HookChild(node);
            programs.Remove(prog);
            BuildTree(node, programs);
        }
    }

    private class Prog
    {
        private bool Equals(Prog other)
        {
            return Name == other.Name;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Prog)obj);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }

        public string Name { get; set; }

        public int Weight { get; set; }

        public List<string> Holds { get; set; }

        public static bool operator ==(Prog p1, Prog p2)
        {
            return p1?.Name == p2?.Name;
        }

        public static bool operator !=(Prog p1, Prog p2)
        {
            return !(p1 == p2);
        }
    }
}
