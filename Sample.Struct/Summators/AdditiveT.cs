namespace Sample.Struct.Summators;

public readonly ref struct Additive<T, TSummator> where TSummator : struct, ISummator<T>
{
    private Additive(T value)
    {
        Value = value;
    }

    public T Value { get; }

    public static Additive<T, TSummator> operator +(Additive<T, TSummator> left, Additive<T, TSummator> right)
    {
        var summator = default(TSummator);
        return summator.Add(left, right);
    }

    public static implicit operator Additive<T, TSummator>(T value)
    {
        return new Additive<T, TSummator>(value);
    }

    public static implicit operator T(Additive<T, TSummator> value)
    {
        return value.Value;
    }
}
