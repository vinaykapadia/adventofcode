namespace AdventOfCode.Common.Rational;

public partial struct Rational
{
    public static Rational FromDouble(double value, int maxIterations = int.MaxValue, double threshold = double.Epsilon)
    {
        var whole = (long)Math.Floor(value);
        value -= whole;

        if (value < threshold)
            return new Rational(whole);

        if (1 - threshold < value)
            return new Rational(whole + 1);

        var low = new Rational(0);
        var high = new Rational(1);

        for (var i = 0; i < maxIterations; ++i)
        {
            var mid = new Rational(low.Numerator + high.Numerator, low.Denominator + high.Denominator);
            if (mid.Numerator > mid.Denominator * (value + threshold))
                high = mid;
            else if (mid.Numerator < mid.Denominator * (value - threshold))
                low = mid;
            else
                return new Rational(whole * mid.Denominator + mid.Numerator, mid.Denominator);
        }

        throw new ArithmeticException("Failed to solve.");
    }
}