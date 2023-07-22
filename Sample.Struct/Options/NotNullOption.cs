namespace Sample.Struct.Options;

public static class NotNullOption
{
    public static Option<T, NotNullOption<T>> AsOption<T>(this NotNull<T> notNull) where T : class
    {
        return new Option<T, NotNullOption<T>>(new NotNullOption<T>(notNull));
    }
}
