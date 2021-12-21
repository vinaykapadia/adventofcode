namespace AdventOfCode.Common.Rational;

public partial struct Rational : IComparable<Rational>, IComparable
{
    public int CompareTo(Rational other)
    {
        long diff;

        if (Denominator == other.Denominator)
            diff = Numerator - other.Numerator;
        else
        {
            var whole1 = Numerator / Denominator;
            var whole2 = other.Numerator / other.Denominator;
            diff = whole1 - whole2;

            if (diff == 0)
            {
                var n1 = Numerator % Denominator;
                var n2 = other.Numerator % other.Denominator;

                checked
                {
                    diff = n1 * other.Denominator - n2 * Denominator;
                }
            }
        }

        return diff == 0 ? 0 : diff > 0 ? 1 : -1;
    }

    public int CompareTo(object value)
    {
        if (value == null)
            return 1;
        if (value is not Rational rational)
            throw new ArgumentException("must be rational");

        return CompareTo(rational);
    }
}