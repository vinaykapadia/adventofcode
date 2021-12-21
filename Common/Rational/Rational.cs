using System.Globalization;

namespace AdventOfCode.Common.Rational;

public partial struct Rational : IEquatable<Rational>, IFormattable
{
    public Rational(long numerator, long denominator = 1) : this()
    {
        if (denominator == 0)
            throw new ArgumentOutOfRangeException(nameof(denominator), "The denominator cannot be 0.");

        Initialise(numerator, denominator);
    }

    private void Initialise(long numerator, long denominator)
    {
        if (denominator == 1)
        {
            Numerator = numerator;
            Denominator = 1;
        }
        else if (numerator == denominator)
        {
            Numerator = 1;
            Denominator = 1;
        }
        else if (numerator == 0)
        {
            Numerator = 0;
            Denominator = 1;
        }
        else
        {
            var gcd = Algorithms.Gcd(numerator, denominator);
            numerator /= gcd;
            denominator /= gcd;
            Numerator = denominator < 0 ? -numerator : numerator;
            Denominator = denominator < 0 ? -denominator : denominator;
        }
    }

    public long Numerator { get; private set; }
    public long Denominator { get; private set; }

    public bool IsValid => Denominator != 0;

    public static Common.Rational.Rational Empty => new();
    public static Common.Rational.Rational Zero => new(0);
    public static Common.Rational.Rational One => new(1);

    public bool Equals(Common.Rational.Rational other)
    {
        return Numerator == other.Numerator && Denominator == other.Denominator;
    }

    public override bool Equals(object obj)
    {
        return obj is Common.Rational.Rational rational && Equals(rational);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return (Numerator.GetHashCode() * 397) ^ Denominator.GetHashCode();
        }
    }

    public override string ToString()
    {
        return ToString("L", null);
    }

    public string ToString(string format, IFormatProvider provider)
    {
        if (string.IsNullOrWhiteSpace(format))
            format = "L";

        switch (format[0])
        {
            case 'S':
            case 's':
                return string.Concat(Numerator, '/', Denominator);

            case 'L':
            case 'l':
                if (Denominator == 1)
                    return Numerator.ToString(CultureInfo.InvariantCulture);

                if ((Numerator >= 0 && Numerator < Denominator) || (Numerator < 0 && -Numerator < Denominator))
                    return string.Concat(Numerator, '/', Denominator);

                if (Numerator < 0)
                    return string.Concat(Numerator / Denominator, ' ', -Numerator % Denominator, '/', Denominator);

                return string.Concat(Numerator / Denominator, ' ', Numerator % Denominator, '/', Denominator);

            case 'D':
            case 'd':
            case 'X':
            case 'x':
            case 'N':
            case 'n':
                return (Numerator / Denominator).ToString(format, provider);

            case 'C':
            case 'c':
            case 'E':
            case 'e':
            case 'F':
            case 'f':
            case 'G':
            case 'g':
            case 'P':
            case 'p':
            case 'R':
            case 'r':
                return ((double)Numerator / Denominator).ToString(format, provider);

            default:
                throw new FormatException(string.Concat("Unknown format string: \"", format, "\"."));
        }
    }
}