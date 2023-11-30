using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace AdventOfCode._2022.Day11;

[ProblemName("Monkey in the Middle")]      
internal class Solution : ISolver
{

    public object PartOne(string input) => RunMonkeys(input.Lines(), 3, 20);

    //11521878962 too low
    public object PartTwo(string input) => RunMonkeys(input.Lines(), 1, 10000);

    private static long RunMonkeys(IReadOnlyList<string> lines, long worryDivisor, long rounds)
    {
        AutoAddingDictionary<long, Monkey> monkeys = new();

        for (int i = 0; i < lines.Count; i++)
        {
            Monkey monkey = new();

            long num = long.Parse(lines[i][7..8]);
            i++;

            var split = Regex.Split(lines[i], @"\D+");
            foreach (var number in split)
            {
                if (number != "")
                {
                    var item = new Item { Worry = long.Parse(number) };
                    monkey.Items.Enqueue(item);
                }
            }
            i++;

            var operation = lines[i][19..];
            split = operation.Split(' ');
            Expression left = Expression.Parameter(typeof(long), "old");
            var right = split[2].StartsWith("old") ? left : Expression.Constant(long.Parse(split[2]));
            Expression expression = split[1] switch
            {
                "+" => Expression.Add(left, right),
                "-" => Expression.Subtract(left, right),
                "*" => Expression.Multiply(left, right),
                "/" => Expression.Divide(left, right),
                _ => throw new ArgumentOutOfRangeException()
            };
            monkey.Operation = Expression.Lambda<Func<long, long>>(expression, (ParameterExpression)left).Compile();
            i++;

            monkey.Test = long.Parse(lines[i][21..]);
            i++;

            monkey.TrueMonkey = long.Parse(lines[i][29..]);
            i++;

            monkey.FalseMonkey = long.Parse(lines[i][30..]);
            i++;

            monkeys.Add(num, monkey);
        }

        for (long round = 0; round < rounds; round++)
        {
            for (long i = 0; i < monkeys.Count; i++)
            {
                while (monkeys[i].Items.TryDequeue(out var item))
                {
                    monkeys[i].Inspections++;
                    item.Worry = monkeys[i].Operation(item.Worry) / worryDivisor;
                    long throwTo = item.Worry % monkeys[i].Test == 0 ? monkeys[i].TrueMonkey : monkeys[i].FalseMonkey;
                    monkeys[throwTo].Items.Enqueue(item);
                }
            }
        }

        var sorted = monkeys.Select(y => y.Value.Inspections).OrderByDescending(x => x).ToList();
        return sorted[0] * sorted[1];
    }
}

internal class Item
{
    public long Worry { get; set; }
}

internal class Monkey
{
    public Queue<Item> Items { get; set; } = new();
    
    public long Test { get; set; }

    public Func<long, long> Operation { get; set; }

    public long TrueMonkey { get; set; }

    public long FalseMonkey { get; set; }

    public long Inspections { get; set; } = 0;
}
