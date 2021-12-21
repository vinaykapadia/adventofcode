using System.Security.Cryptography.X509Certificates;

namespace AdventOfCode._2019.Day12;

[ProblemName("The N-Body Problem")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        var position = new (int x, int y, int z)[4];
        var velocity = new (int x, int y, int z)[4];
        var original = new (int x, int y, int z)[4];

        // Set up data, typed in from input
        original[0] = (7, 10, 17);
        original[1] = (-2, 7, 0);
        original[2] = (12, 5, 12);
        original[3] = (5, -8, 6);

        for (var j = 0; j < 4; j++)
        {
            position[j] = (original[j].Item1, original[j].Item2, original[j].Item3);
            velocity[j] = (0, 0, 0);
        }

        long i;
        for (i = 0; i < 1000; i++)
        {
            TimeStep(position, velocity);
        }

        var energy = 0;
        // calc Energy
        for (var j = 0; j < 4; j++)
        {
            energy += (Math.Abs(position[j].x) + Math.Abs(position[j].y) + Math.Abs(position[j].z)) * (Math.Abs(velocity[j].x) + Math.Abs(velocity[j].y) + Math.Abs(velocity[j].z));
        }

        return energy;
    }

    public object PartTwo(string input)
    {
        // Part 2, incorrect
        /*bool start = false;

        while (!start)
        {
            TimeStep(position, velocity);
            i++;
            start = true;
            for (int j = 0; j < 4 && start; j++)
            {
                if (position[j].Item1 != original[j].Item1 || position[j].Item2 != original[j].Item2 ||
                    position[j].Item3 != original[j].Item3 || velocity[j].Item1 != 0 || velocity[j].Item2 != 0 ||
                    velocity[j].Item3 != 0)
                {
                    start = false;
                }
            }
        }*/

        return 0;
    }

    private static void TimeStep(IList<(int x, int y, int z)> position, IList<(int x, int y, int z)> velocity)
    {
        // calc velocity
        for (var j = 0; j < 4; j++)
        {
            var (x, y, z) = velocity[j];
            for (var k = 0; k < 4; k++)
            {
                if (j == k) continue;
                if (position[j].x > position[k].x) x--;
                if (position[j].x < position[k].x) x++;
                if (position[j].y > position[k].y) y--;
                if (position[j].y < position[k].y) y++;
                if (position[j].z > position[k].z) z--;
                if (position[j].z < position[k].z) z++;
            }

            velocity[j] = (x, y, z);
        }

        // calc position
        for (var j = 0; j < 4; j++)
        {
            var x = position[j].x + velocity[j].x;
            var y = position[j].y + velocity[j].y;
            var z = position[j].z + velocity[j].z;
            position[j] = (x, y, z);
        }
    }
}
