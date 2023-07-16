namespace Sample.Struct;

public static class NotNull
{
    public static NotNull<T> EnsureNotNull<T>(this NotNull<T> value) => value;
    public static NotNull<T> EnsureNotNull<T>([NotNull] this T value) => value.EnsureNotNull(string.Empty);

    public static NotNull<T> EnsureNotNull<T>([NotNull] this T value, string name)
    {
        if (value == null)
            throw new ArgumentNullException(name);
        return new NotNull<T>(value);
    }

    public static NotNull<T> AsNotNull<T>(this T value) where T : struct => new(value);
    public static NotNull<T> AsNotNull<T>(this NotNull<T> value) where T : struct => value;
    public static NotNull<T> CannotBeNull<T>([NotNull] this T reference) where T : class => new(reference);

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

public readonly struct NotNull<T> : IEquatable<NotNull<T>>
{
    internal NotNull([NotNull] T unwrap) => Value = unwrap;

    [NotNull] public T Value { get; }

    public override int GetHashCode() => Value.GetHashCode();
    public override string ToString() => $"NotNull {Value}";
    public override bool Equals(object obj) => obj is NotNull<T> notNull && Equals(notNull);
    public bool Equals(NotNull<T> other) => Value.Equals(other.Value);
    public static bool operator ==(NotNull<T> left, NotNull<T> right) => left.Equals(right);
    public static bool operator !=(NotNull<T> left, NotNull<T> right) => !left.Equals(right);
    public static implicit operator T(NotNull<T> t) => t.Value;
    public static implicit operator NotNull<T>(T value) => value.EnsureNotNull();
}