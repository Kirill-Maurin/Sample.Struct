namespace Sample.Struct.Options;

public static class OptionClass
{
    public static OptionClass<T> ToOptionClass<T>(this T value)
    {
        return value == null ? Null<T>() : new OptionClass<T>(value);
    }

    public static OptionClass<T> Null<T>()
    {
        return OptionClass<T>.Null;
    }
}
