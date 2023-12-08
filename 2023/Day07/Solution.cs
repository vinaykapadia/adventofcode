namespace AdventOfCode._2023.Day07;

[ProblemName("Camel Cards")]      
internal class Solution : ISolver
{
    private static bool _isPartB;

    public object PartOne(string input)
    {
        _isPartB = false;
        return GetTotal(input);
    }

    public object PartTwo(string input)
    {
        _isPartB = true;
        return GetTotal(input);
    }

    private static int GetTotal(string input)
    {
        var players = input.Lines().Select(line => line.Split(' ')).Select(split => new Player { Hand = split[0], Bid = int.Parse(split[1]) }).ToList();
        players.Sort();
        return players.Select((t, i) => (i + 1) * t.Bid).Sum();
    }

    private class Player : IComparable
    {
        public string Hand { get; init; }
        public int Bid { get; init; }

        private int Type()
        {
            var cardNames = _isPartB ? "AKQT98765432" : "AKQJT98765432";

            var counts = cardNames.Select(cardName => Hand.Count(x => x == cardName)).ToList();

            if (_isPartB) counts[counts.IndexOf(counts.Max())] += Hand.Count(x => x == 'J');

            if (counts.Contains(5)) return 7;
            if (counts.Contains(4)) return 6;

            if (counts.Contains(3))
            {
                return counts.Contains(2) ? 5 : 4;
            }

            if (counts.Contains(2))
            {
                counts.Remove(2);
                return counts.Contains(2) ? 3 : 2;
            }

            return 1;
        }

        private int Strength(int num) => Hand[num] switch
        {
            'A' => 14,
            'K' => 13,
            'Q' => 12,
            'J' => _isPartB ? 1 : 11,
            'T' => 10,
            '9' => 9,
            '8' => 8,
            '7' => 7,
            '6' => 6,
            '5' => 5,
            '4' => 4,
            '3' => 3,
            '2' => 2,
            _ => 0
        };

        public int CompareTo(object obj) => CompareTo((Player) obj);

        private int CompareTo(Player player2)
        {
            var result = Type().CompareTo(player2.Type());

            if (result == 0)
            {
                for (var i = 0; i < 5 && result == 0; i++)
                {
                    result = Strength(i).CompareTo(player2.Strength(i));
                }
            }

            return result;
        }
    }
}
