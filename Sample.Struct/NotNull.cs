namespace Sample.Struct;

using System;

public static class NotNull
{
    public static NotNull<T> EnsureNotNull<T>(this NotNull<T> value)
    {
        return value;
    }

    public static NotNull<T> EnsureNotNull<T>([NotNull] this T value)
    {
        return value.EnsureNotNull(string.Empty);
    }

    public static NotNull<T> EnsureNotNull<T>([NotNull] this T value, string name)
    {
        if (value == null)
            throw new ArgumentNullException(name);
        return new NotNull<T>(value);
    }

    public static NotNull<T> AsNotNull<T>(this T value) where T : struct
    {
        return new NotNull<T>(value);
    }

    public static NotNull<T> AsNotNull<T>(this NotNull<T> value) where T : struct
    {
        return value;
    }

    public static NotNull<T> CannotBeNull<T>([NotNull] this T reference) where T : class
    {
        return new NotNull<T>(reference);
    }

    public static bool TryCreate<T>(T value, out NotNull<T> notNull)
    {
        if (value == null)
        {
            notNull = default;
            return false;
        }

        notNull = new NotNull<T>(value);
        return true;
    }
}
