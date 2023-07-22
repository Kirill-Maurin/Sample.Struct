namespace Sample.Struct;

using System;

public readonly struct NotNull<T> : IEquatable<NotNull<T>>
{
    internal NotNull([NotNull] T unwrap)
    {
        Value = unwrap;
    }

    [NotNull] public T Value { get; }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public override string ToString()
    {
        return $"NotNull {Value}";
    }

    public override bool Equals(object obj)
    {
        return obj is NotNull<T> notNull && Equals(notNull);
    }

    public bool Equals(NotNull<T> other)
    {
        return Value.Equals(other.Value);
    }

    public static bool operator ==(NotNull<T> left, NotNull<T> right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(NotNull<T> left, NotNull<T> right)
    {
        return !left.Equals(right);
    }

    public static implicit operator T(NotNull<T> t)
    {
        return t.Value;
    }

    public static implicit operator NotNull<T>(T value)
    {
        return value.EnsureNotNull();
    }
}
