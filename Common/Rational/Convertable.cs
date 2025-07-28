namespace AdventOfCode.Common.Rational;

public partial struct Rational : IConvertible
{
    public TypeCode GetTypeCode()
    {
        throw new InvalidOperationException();
    }

    public bool ToBoolean(IFormatProvider provider)
    {
        return Numerator != 0;
    }

    public char ToChar(IFormatProvider provider)
    {
        throw new InvalidCastException("no valid cast to char");
    }

    public sbyte ToSByte(IFormatProvider provider)
    {
        return (sbyte)(Numerator / Denominator);
    }

    public byte ToByte(IFormatProvider provider)
    {
        return (byte)(Numerator / Denominator);
    }

    public short ToInt16(IFormatProvider provider)
    {
        return (short)(Numerator / Denominator);
    }

    public ushort ToUInt16(IFormatProvider provider)
    {
        return (ushort)(Numerator / Denominator);
    }

    public int ToInt32(IFormatProvider provider)
    {
        return (int)(Numerator / Denominator);
    }

    public uint ToUInt32(IFormatProvider provider)
    {
        return (uint)(Numerator / Denominator);
    }

    public long ToInt64(IFormatProvider provider)
    {
        return Numerator / Denominator;
    }

    public ulong ToUInt64(IFormatProvider provider)
    {
        return (ulong)(Numerator / Denominator);
    }

    public float ToSingle(IFormatProvider provider)
    {
        return (float)((double)Numerator / Denominator);
    }

    public double ToDouble(IFormatProvider provider)
    {
        return (double)Numerator / Denominator;
    }

    public decimal ToDecimal(IFormatProvider provider)
    {
        return (decimal)Numerator / Denominator;
    }

    public DateTime ToDateTime(IFormatProvider provider)
    {
        throw new InvalidCastException("no valid cast to DateTime");
    }

    public string ToString(IFormatProvider provider)
    {
        return ToString("L", provider);
    }

    public object ToType(Type type, IFormatProvider provider)
    {
        return Type.GetTypeCode(type) switch
        {
            TypeCode.Boolean => ToBoolean(provider),
            TypeCode.Char => ToChar(provider),
            TypeCode.SByte => ToSByte(provider),
            TypeCode.Byte => ToByte(provider),
            TypeCode.Int16 => ToInt16(provider),
            TypeCode.UInt16 => ToUInt16(provider),
            TypeCode.Int32 => ToInt32(provider),
            TypeCode.UInt32 => ToUInt32(provider),
            TypeCode.Int64 => ToInt64(provider),
            TypeCode.UInt64 => ToUInt64(provider),
            TypeCode.Single => ToSingle(provider),
            TypeCode.Double => ToDouble(provider),
            TypeCode.Decimal => ToDecimal(provider),
            TypeCode.DateTime => ToDateTime(provider),
            TypeCode.String => ToString(provider),
            TypeCode.Empty => Empty,
            TypeCode.Object => this,
            TypeCode.DBNull => this,
            _ => throw new InvalidCastException("no valid cast to " + type.Name)
        };
    }
}