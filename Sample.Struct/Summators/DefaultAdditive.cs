namespace Sample.Struct.Summators;

public static class DefaultAdditive
{
    public static Additive<T, DefaultSummatorT<T>> AsDefaultAdditive<T>(this T value)
    {
        return value;
    }

    public static Additive<TAccumulator, T, DefaultSummator<TAccumulator, T>> AsAccumulator<TAccumulator, T>
        (this TAccumulator value, T _)
    {
        return value;
    }
}
