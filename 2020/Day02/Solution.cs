namespace AdventOfCode._2020.Day02;

[ProblemName("Password Philosophy")]      
internal class Solution : ISolver
{
    private List<PasswordSet> passwordList = new();

    public object PartOne(string input)
    {
        passwordList = input.Lines().Select(inputLine => inputLine.Split('-', ' '))
            .Select(tokens => new PasswordSet
            {
                AtLeast = int.Parse(tokens[0]),
                AtMost = int.Parse(tokens[1]),
                Letter = tokens[2][0],
                Password = tokens[3]
            }).ToList();

        return passwordList.Count(x => x.Password.Count(y => y == x.Letter) >= x.AtLeast && x.Password.Count(y => y == x.Letter) <= x.AtMost);
    }

    public object PartTwo(string input)
    {
        return passwordList.Count(x =>
        {
            x.AtLeast--;
            x.AtMost--;
            var first = x.AtLeast < x.Password.Length && x.Password[x.AtLeast] == x.Letter;
            var last = x.AtMost < x.Password.Length && x.Password[x.AtMost] == x.Letter;
            return first ^ last;
        });
    }

    private class PasswordSet
    {
        public int AtLeast { get; set; }
        public int AtMost { get; set; }
        public char Letter { get; init; }
        public string Password { get; init; }
    }
}
