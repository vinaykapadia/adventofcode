namespace AdventOfCode.Common.Rational;

public partial struct Rational
{
    public static Rational operator -(Rational a)
    {
        return a.Negate();
    }

    public static Rational operator +(Rational a, Rational b)
    {
        return a.Add(b);
    }

    public static Rational operator +(Rational a, long b)
    {
        return a.Add(b);
    }

    public static Rational operator +(long a, Rational b)
    {
        return b.Add(a);
    }

    public static Rational operator ++(Rational a)
    {
        a.Initialise(a.Numerator + a.Denominator, a.Denominator);
        return a;
    }

    public static Rational operator -(Rational a, Rational b)
    {
        return a.Subtract(b);
    }

    public static Rational operator -(Rational a, long b)
    {
        return a.Subtract(b);
    }

    public static Rational operator -(long a, Rational b)
    {
        return b.Negate().Add(a);
    }

    public static Rational operator --(Rational a)
    {
        a.Initialise(a.Numerator - a.Denominator, a.Denominator);
        return a;
    }

    public static Rational operator *(Rational a, Rational b)
    {
        return a.Multiply(b);
    }

    public static Rational operator *(Rational a, long b)
    {
        return a.Multiply(b);
    }

    public static Rational operator *(long a, Rational b)
    {
        return b.Multiply(a);
    }

    public static Rational operator /(Rational a, Rational b)
    {
        return a.Divide(b);
    }

    public static Rational operator /(Rational a, long b)
    {
        return a.Divide(b);
    }

    public static Rational operator /(long a, Rational b)
    {
        return b.Invert().Multiply(a);
    }

    public static bool operator ==(Rational a, Rational b)
    {
        return a.Equals(b);
    }

    public static bool operator !=(Rational a, Rational b)
    {
        return !a.Equals(b);
    }

    public static bool operator >(Rational a, Rational b)
    {
        return a.CompareTo(b) > 0;
    }

    public static bool operator >=(Rational a, Rational b)
    {
        return a.CompareTo(b) >= 0;
    }

    public static bool operator <(Rational a, Rational b)
    {
        return a.CompareTo(b) < 0;
    }

    public static bool operator <=(Rational a, Rational b)
    {
        return a.CompareTo(b) <= 0;
    }

    public static implicit operator Rational(long value)
    {
        return new Rational(value);
    }

    public static explicit operator long(Rational value)
    {
        return value.Numerator / value.Denominator;
    }

    public static explicit operator double(Rational value)
    {
        return (double)value.Numerator / value.Denominator;
    }

    public static explicit operator Rational(double value)
    {
        return FromDouble(value, 8);
    }
}