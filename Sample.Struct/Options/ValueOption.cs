namespace Sample.Struct.Options;

public static class ValueOption
{
    public static ValueOption<T> AsOption<T>(this T? nullable) where T : struct
    {
        return new ValueOption<T>(nullable);
    }

    public static ValueOption<T> AsOption<T>(this ValueOption<T> option) where T : struct
    {
        return option;
    }

    public static T? AsNullable<T>(this ValueOption<T> option) where T : struct
    {
        return option.TryGetValue(out NotNull<T> v) ? new T?(v) : null;
    }
}
