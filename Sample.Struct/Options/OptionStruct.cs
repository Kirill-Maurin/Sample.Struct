namespace Sample.Struct.Options;

public static class OptionStruct
{
    public static OptionStruct<T> ToOptionStruct<T>(this T value)
    {
        return value == null ? Null<T>() : new OptionStruct<T>(value);
    }

    public static OptionStruct<T> Null<T>()
    {
        return OptionStruct<T>.Null;
    }
}
