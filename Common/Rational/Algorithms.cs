namespace AdventOfCode.Common.Rational;

public static class Algorithms
{
    public static long Gcd(long a, long b)
    {
        bool aNeg = a < 0, bNeg = b < 0;
        if (aNeg) a = -a;
        if (bNeg) b = -b;

        var gcd = Gcd((ulong)a, (ulong)b);
        return aNeg == bNeg ? (long)gcd : -((long)gcd);
    }

    public static ulong Gcd(ulong a, ulong b)
    {
        while (a != 0 && b != 0)
        {
            if (a > b)
                a %= b;
            else
                b %= a;
        }

        return a == 0 ? b : a;
    }
}