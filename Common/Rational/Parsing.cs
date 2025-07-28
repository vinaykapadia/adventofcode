namespace AdventOfCode.Common.Rational;

public partial struct Rational
{
    public static Rational Parse(string s)
    {
        if (s == null) throw new ArgumentNullException(nameof(s));

        if (!TryParse(s, out var rational)) throw new FormatException();
        return rational;
    }

    public static bool TryParse(string s, out Rational rational)
    {
        if (s != null)
        {
            s = s.Trim();
            var slashIndex = s.IndexOf('/');
            if (slashIndex == -1)
            {
                if (long.TryParse(s, out var whole))
                {
                    rational = new Rational(whole);
                    return true;
                }
            }
            else
            {
                var denominatorString = s[(slashIndex + 1)..].TrimStart();
                if (long.TryParse(denominatorString, out var denominator))
                {
                    long numerator;
                    var numeratorString = s[..slashIndex].TrimEnd();
                    var spaceIndex = numeratorString.IndexOf(' ');
                    if (spaceIndex == -1)
                    {
                        if (long.TryParse(numeratorString, out numerator))
                        {
                            rational = new Rational(numerator, denominator);
                            return true;
                        }
                    }
                    else
                    {
                        if (long.TryParse(numeratorString[..spaceIndex].TrimEnd(), out var whole)
                            && long.TryParse(numeratorString[(spaceIndex + 1)..].TrimStart(), out numerator)
                            && numerator >= 0)
                        {
                            rational = new Rational(whole * denominator + numerator, denominator);
                            return true;
                        }
                    }
                }
            }
        }

        rational = default;
        return false;
    }
}