namespace Sample.Struct.Options;

using System;

public readonly struct OptionStruct<T> : IOption<T>, IEquatable<OptionStruct<T>>
{
    internal OptionStruct(in T value)
    {
        (this.HasValue, this.Value) = (true, value);
    }

    public bool HasValue { get; }

    public bool TryGetValue(out NotNull<T> value)
    {
        value = this.Value;
        return this.HasValue;
    }

    private NotNull<T> Value { get; }

    internal static OptionStruct<T> Null { get; } = new();

    public bool Equals(OptionStruct<T> option)
    {
        return this.HasValue == option.HasValue && (!this.HasValue || this.Value.Equals(option.Value));
    }

    public override bool Equals(object obj)
    {
        return obj is OptionStruct<T> option && this.Equals(option);
    }

    public override int GetHashCode()
    {
        return this.HasValue ? this.Value.GetHashCode() : 2019994878;
    }

    public static bool operator ==(OptionStruct<T> left, OptionStruct<T> right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(OptionStruct<T> left, OptionStruct<T> right)
    {
        return !(left == right);
    }
}
