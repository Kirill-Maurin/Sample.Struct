namespace Sample.Struct.Summators;

public readonly ref struct Additive<TAccumulator, TIncrement, TSummator>
    where TSummator : struct, ISummator<TAccumulator, TIncrement>
{
    private Additive(TAccumulator value)
    {
        Value = value;
    }

    public TAccumulator Value { get; }

    public static Additive<TAccumulator, TIncrement, TSummator> operator +
        (Additive<TAccumulator, TIncrement, TSummator> left, TIncrement right)
    {
        var summator = default(TSummator);
        return summator.Add(left, right);
    }

    public static implicit operator Additive<TAccumulator, TIncrement, TSummator>(TAccumulator value)
    {
        return new Additive<TAccumulator, TIncrement, TSummator>(value);
    }

    public static implicit operator TAccumulator(Additive<TAccumulator, TIncrement, TSummator> value)
    {
        return value.Value;
    }
}
