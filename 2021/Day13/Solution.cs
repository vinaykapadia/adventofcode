using System.Security.Cryptography.X509Certificates;

namespace AdventOfCode._2021.Day13;

[ProblemName("Transparent Origami")]      
internal class Solution : ISolver
{
    public class Coord
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coord(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class CoordEquality : IEqualityComparer<Coord>
    {
        public bool Equals(Coord x, Coord y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.X == y.X && x.Y == y.Y;
        }

        public int GetHashCode(Coord obj)
        {
            return HashCode.Combine(obj.X, obj.Y);
        }
    }

    public object PartOne(string input)
    {
        var coords = new List<Coord>();
        var lines = input.Lines();
        var i = 0;
        while (lines[i] != "")
        {
            var split = lines[i].Split(',').Select(int.Parse).ToArray();
            coords.Add(new Coord(split[0], split[1]));
            i++;
        }

        i++;

        var foldLine = int.Parse(lines[i][(lines[i].IndexOf('=') + 1)..]);
        var axis = lines[i][lines[i].IndexOf('=') - 1];
        Fold(coords, axis, foldLine);

        var partAAnswer = coords.Distinct(new CoordEquality()).Count();

        for (i++; i < lines.Length; i++)
        {
            foldLine = int.Parse(lines[i][(lines[i].IndexOf('=') + 1)..]);
            axis = lines[i][lines[i].IndexOf('=') - 1];
            Fold(coords, axis, foldLine);
        }

        PartBAnswer = coords;
        return partAAnswer;
    }

    public object PartTwo(string input)
    {
        var coords = (List<Coord>)PartBAnswer;
        var maxX = coords.Max(x => x.X) + 1;
        var maxY = coords.Max(y => y.Y) + 1;

        var lit = new bool[maxX, maxY];
        foreach (var coord in coords)
        {
            lit[coord.X, coord.Y] = true;
        }

        for (int j = 0; j < maxY; j++)
        {
            for (int i = 0; i < maxX; i++)
            {
                Console.Write(lit[i, j] ? '*' : ' ');
            }

            Console.WriteLine();
        }

        // Just checked the console output and put that here.
        return "LGHEGUEJ";
    }

    private void Fold(List<Coord> coords, char axis, int foldLine)
    {
        switch (axis)
        {
            case 'x':
            {
                foreach (var coord in coords.Where(c => c.X > foldLine))
                {
                    coord.X = foldLine + foldLine - coord.X;
                }

                break;
            }
            case 'y':
            {
                foreach (var coord in coords.Where(c => c.Y > foldLine))
                {
                    coord.Y = foldLine + foldLine - coord.Y;
                }

                break;
            }
        }
    }
}
