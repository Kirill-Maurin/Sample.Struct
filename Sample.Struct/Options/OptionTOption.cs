namespace Sample.Struct.Options;

using System;

public readonly struct Option<T, TOption> : IOption<T>, IEquatable<Option<T, TOption>> where TOption : IOption<T>
{
    public Option(in TOption option)
    {
        this.Value = option;
    }

    public bool TryGetValue(out NotNull<T> value)
    {
        return this.Value.TryGetValue(out value);
    }

    public override bool Equals(object obj)
    {
        return obj is Option<T, TOption> option && this.Equals(option);
    }

    public override int GetHashCode()
    {
        return this.Value.GetHashCode();
    }

    public override string ToString()
    {
        return this.Value.ToString();
    }

    public bool HasValue => this.Value.HasValue;
    public TOption Value { get; }

    public bool Equals(Option<T, TOption> other)
    {
        return this.Value.Equals(other.Value);
    }

    public bool Equals(TOption other)
    {
        return other.Equals(this.Value);
    }

    public static implicit operator TOption(Option<T, TOption> t)
    {
        return t.Value;
    }

    public static bool operator ==(Option<T, TOption> left, Option<T, TOption> right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Option<T, TOption> left, Option<T, TOption> right)
    {
        return !(left == right);
    }
}
