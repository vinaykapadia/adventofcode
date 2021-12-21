namespace AdventOfCode._2021.Day04;

[ProblemName("Giant Squid")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        var lines = input.Lines();
        var numbers = lines[0].Split(',').Select(int.Parse).ToArray();
        var boards = new List<int[]>();

        for (var i = 2; i < lines.Length; i += 6)
        {
            var board = new int[25];
            for (var j = 0; j < 5; j++)
            {
                var read = lines[i + j].Replace("  ", " ");
                if (read[0] == ' ') read = read[1..];
                var row = read.Replace("  ", " ").Split(' ').Select(int.Parse).ToArray();
                for (var k = 0; k < 5; k++)
                {
                    board[j * 5 + k] = row[k];
                }
            }
            boards.Add(board);
        }

        var total = boards.Count;
        var numDone = 0;
        int partA = 0;

        for (var i = 0; numDone < total && i < numbers.Length; i++)
        {
            var j = 0;
            while (j < boards.Count)
            {
                Mark(boards[j], numbers[i]);
                if (IsWinner(boards[j]))
                {
                    numDone++;
                    if (numDone == 1)
                    {
                        partA = boards[j].Where(num => num != -1).Sum();
                        partA *= numbers[i];
                    }

                    if (numDone == total)
                    {
                        var answer = boards[j].Where(num => num != -1).Sum();
                        answer *= numbers[i];
                        PartBAnswer = answer;
                    }

                    boards.RemoveAt(j);
                    j--;
                }

                j++;
            }
        }

        return partA;
    }

    public object PartTwo(string input)
    {
        return PartBAnswer;
    }

    private static void Mark(IList<int> board, int num)
    {
        for (var i = 0; i < board.Count; i++)
        {
            if (board[i] == num)
            {
                board[i] = -1;
                return;
            }
        }
    }

    private static bool IsWinner(IReadOnlyList<int> board)
    {
        for (var i = 0; i < 5; i++)
        {
            if (board[i] == -1
                && board[i + 5] == -1
                && board[i + 10] == -1
                && board[i + 15] == -1
                && board[i + 20] == -1)
            {
                return true;
            }
        }

        for (var i = 0; i < 25; i += 5)
        {
            if (board[i] == -1
                && board[i + 1] == -1
                && board[i + 2] == -1
                && board[i + 3] == -1
                && board[i + 4] == -1)
            {
                return true;
            }
        }

        return false;
    }
}
