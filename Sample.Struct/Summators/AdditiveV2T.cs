namespace Sample.Struct.Summators;

public struct AdditiveV2<T, TSummator> where TSummator : struct, ISummator<T>
{
    private AdditiveV2(T value)
    {
        Value = value;
    }

    public T Value { get; }

    public static AdditiveV2<T, TSummator> operator +(AdditiveV2<T, TSummator> left, AdditiveV2<T, TSummator> right)
    {
        return default(TSummator).Add(left, right);
    }

    public static implicit operator AdditiveV2<T, TSummator>(T value)
    {
        return new AdditiveV2<T, TSummator>(value);
    }

    public static implicit operator T(AdditiveV2<T, TSummator> value)
    {
        return value.Value;
    }
}
