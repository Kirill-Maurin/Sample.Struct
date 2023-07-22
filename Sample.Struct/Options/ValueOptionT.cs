namespace Sample.Struct.Options;

using System;
using System.Collections.Generic;

public readonly struct ValueOption<T> : IOption<T>, IEquatable<ValueOption<T>> where T : struct
{
    internal ValueOption(in T? nullable)
    {
        (this.Value, this.HasValue) = (nullable ?? default, nullable.HasValue);
    }

    public bool TryGetValue(out NotNull<T> value)
    {
        value = new NotNull<T>(this.Value);
        return this.HasValue;
    }

    public override bool Equals(object obj)
    {
        return obj is ValueOption<T> option && this.Equals(option);
    }

    public override int GetHashCode()
    {
        return this.HasValue ? this.Value.GetHashCode() : 2019994878;
    }

    public override string ToString()
    {
        return this.TryGetValue(out NotNull<T> v) ? $"Option {v}" : $"Null<{nameof(T)}>";
    }

    public bool HasValue { get; }
    private T Value { get; }

    public bool Equals(ValueOption<T> other)
    {
        return this.HasValue == other.HasValue &&
               (!this.HasValue || EqualityComparer<T>.Default.Equals(this.Value, other.Value));
    }

    public static implicit operator T?(ValueOption<T> option)
    {
        return option.AsNullable();
    }

    public static implicit operator ValueOption<T>(T? nullable)
    {
        return nullable.AsOption();
    }

    public static bool operator ==(ValueOption<T> left, ValueOption<T> right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(ValueOption<T> left, ValueOption<T> right)
    {
        return !(left == right);
    }
}
