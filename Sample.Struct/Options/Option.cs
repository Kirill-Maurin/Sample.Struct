namespace Sample.Struct.Options;

public static class Option
{
    public static Option<T, Option<T>> CanBeNull<T>([CanBeNull] this T reference) where T : class
    {
        return reference.AsOption();
    }

    public static Option<T, Option<T>> AsOption<T>([CanBeNull] this T reference) where T : class
    {
        return new Option<T>(reference).AsOption();
    }

    public static Option<T, Option<T>> AsOption<T>(this Option<T> option) where T : class
    {
        return new Option<T, Option<T>>(option);
    }

    public static Option<T, TO> AsOption<T, TO>(this Option<T, TO> option) where TO : IOption<T>
    {
        return option;
    }

    public static Option<T, NullT<T>> Null<T>()
    {
        return NullT<T>.Instance;
    }

    public static Option<T, NullT<T>> Null<T>(this T _)
    {
        return Null<T>();
    }

    [CanBeNull]
    public static T AsReference<T>(this Option<T> option) where T : class
    {
        return option.TryGetValue(out NotNull<T> reference) ? reference : null;
    }

    [CanBeNull]
    public static T AsReference<T>(this Option<T, Option<T>> option) where T : class
    {
        return option.Value.AsReference();
    }
}
