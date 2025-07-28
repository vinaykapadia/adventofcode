namespace AdventOfCode.Common.Rational;

public partial struct Rational
{
    public readonly Rational Negate()
    {
        return new Rational(-Numerator, Denominator);
    }

    public readonly Rational Invert()
    {
        return new Rational(Denominator, Numerator);
    }

    public readonly Rational Add(Rational rational)
    {
        return Add(rational.Numerator, rational.Denominator);
    }

    public readonly Rational Add(long value)
    {
        checked
        {
            return Add(value * Denominator, Denominator);
        }
    }

    public readonly Rational Subtract(Rational rational)
    {
        return Add(-rational.Numerator, rational.Denominator);
    }

    public readonly Rational Subtract(long value)
    {
        checked
        {
            return Add(-value * Denominator, Denominator);
        }
    }

    public readonly Rational Multiply(Rational rational)
    {
        return Multiply(rational.Numerator, rational.Denominator);
    }

    public readonly Rational Multiply(long value)
    {
        checked
        {
            return Multiply(value * Denominator, Denominator);
        }
    }

    public readonly Rational Divide(Rational rational)
    {
        return Multiply(rational.Denominator, rational.Numerator);
    }

    public readonly Rational Divide(long value)
    {
        checked
        {
            return Multiply(Denominator, value * Denominator);
        }
    }

    public readonly Rational Abs()
    {
        return Numerator < 0 ? new Rational(-Numerator, Denominator) : this;
    }

    public readonly Rational Round(IList<long> targetDenominators)
    {
        var sign = Numerator < 0 ? -1 : 1;
        var numerator = Numerator * sign;
        var whole = numerator / Denominator;
        numerator %= Denominator;
        var local = new Rational(numerator, Denominator);
        var best = new Rational(0);
        var bestError = new Rational(1);

        foreach (var denominator in targetDenominators)
        {
            var d = Denominator / denominator;
            var n = numerator / d;
            if (n != 0)
            {
                var guess = new Rational(whole * denominator + n, denominator);
                var guessError = (local - guess).Abs();
                if (guessError < bestError)
                {
                    best = guess;
                    bestError = guessError;
                }
            }
        }

        return best;
	}

	private readonly Rational Add(long numerator, long denominator)
	{
		checked
		{
			return
				Denominator == denominator
					? new Rational(Numerator + numerator, denominator)
					: new Rational(Numerator * denominator + numerator * Denominator,
						Denominator * denominator);
		}
	}

	private readonly Rational Multiply(long numerator, long denominator)
	{
		checked
		{
			return new Rational(Numerator * numerator, Denominator * denominator);
		}
	}
}