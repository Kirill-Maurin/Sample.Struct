namespace Sample.Struct.Options;

using System;

public readonly struct NotNullOption<T> : IOption<T>, IEquatable<NotNullOption<T>>
{
    internal NotNullOption(NotNull<T> value)
    {
        this.Value = value;
    }

    private NotNull<T> Value { get; }

    public bool TryGetValue(out NotNull<T> value)
    {
        value = this.Value;
        return true;
    }

    public bool HasValue => true;

    public override int GetHashCode()
    {
        return this.Value.GetHashCode();
    }

    public override string ToString()
    {
        return this.Value.ToString();
    }

    public override bool Equals(object obj)
    {
        return obj is NotNullOption<T> option && this.Equals(option);
    }

    public bool Equals(NotNullOption<T> other)
    {
        return this.Value.Equals(other.Value);
    }

    public static bool operator ==(NotNullOption<T> left, NotNullOption<T> right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(NotNullOption<T> left, NotNullOption<T> right)
    {
        return !left.Equals(right);
    }
}
