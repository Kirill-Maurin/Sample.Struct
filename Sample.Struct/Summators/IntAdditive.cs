namespace Sample.Struct.Summators;

public static class IntAdditive
{
    public static Additive<int, IntSummator> AsAdditive(this int value)
    {
        return value;
    }

    public static AdditiveV2<int, IntSummator> AsAdditive2(this int value)
    {
        return value;
    }

    public static Additive<int, IntCheckedSummator> AsCheckedAdditive(this int value)
    {
        return value;
    }

    public static Additive<long, int, LongIntSummator> AsAccumulator(this long value)
    {
        return value;
    }
}
