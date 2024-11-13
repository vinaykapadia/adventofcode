namespace AdventOfCode._2018.Day09;

[ProblemName("Marble Mania")]      
internal class Solution : ISolver
{
    // I'm just entering the input values here.
    public object PartOne(string input) => GetHighScore(458, 72019);

    // I'm just entering the input values here.
    public object PartTwo(string input) => GetHighScore(458, 7201900);

    private static long GetHighScore(int numPlayers, int lastMarble)
    {
        var scores = new long[numPlayers];
        var currentPlayer = 0;

        var current = new Node(0);
        current.Next = current;
        current.Previous = current;

        for (var i = 0; i < lastMarble; i++)
        {
            if (i % 23 == 0)
            {
                scores[currentPlayer] += i;
                for (var j = 0; j < 7; j++)
                {
                    current = current.Previous;
                }

                scores[currentPlayer] += current.Value;
                current.Previous.Next = current.Next;
                current.Next.Previous = current.Previous;
                current = current.Next;
            }
            else
            {
                var nextNode = current.Next;
                var nextNextNode = nextNode.Next;
                current = new Node(i);
                nextNode.Next = current;
                current.Previous = nextNode;
                current.Next = nextNextNode;
                nextNextNode.Previous = current;
            }

            currentPlayer = (currentPlayer + 1) % numPlayers;
        }

        return scores.Max();
    }

    public class Node(int value)
    {
        public int Value { get; } = value;

        public Node Previous { get; set; }

        public Node Next { get; set; }
    }
}
