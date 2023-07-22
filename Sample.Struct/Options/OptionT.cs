namespace Sample.Struct.Options;

using System;
using System.Collections.Generic;

public readonly struct Option<T> : IOption<T>, IEquatable<Option<T>> where T : class
{
    internal Option([CanBeNull] T value)
    {
        this.Value = value;
    }

    public bool TryGetValue(out NotNull<T> value)
    {
        value = new NotNull<T>(this.Value);
        return this.HasValue;
    }

    public override bool Equals(object obj)
    {
        return obj is Option<T> option && this.Equals(option);
    }

    public override int GetHashCode()
    {
        return this.Value?.GetHashCode() ?? 2019994878;
    }

    public override string ToString()
    {
        return this.TryGetValue(out NotNull<T> v) ? $"Option {v}" : $"Null<{nameof(T)}>";
    }

    public bool HasValue => this.Value != null;
    private T Value { get; }

    public bool Equals(Option<T> other)
    {
        return this.HasValue == other.HasValue &&
               (!this.HasValue || EqualityComparer<T>.Default.Equals(this.Value, other.Value));
    }

    public bool Equals(Option<T, Option<T>> other)
    {
        return this.Equals(other.Value);
    }

    public static implicit operator Option<T>(T reference)
    {
        return new Option<T>(reference);
    }

    public static implicit operator Option<T, Option<T>>(Option<T> option)
    {
        return option.AsOption();
    }

    public static bool operator ==(Option<T> left, Option<T> right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Option<T> left, Option<T> right)
    {
        return !(left == right);
    }
}
