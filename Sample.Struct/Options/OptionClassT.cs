namespace Sample.Struct.Options;

using System;

public sealed class OptionClass<T> : IOption<T>, IEquatable<OptionClass<T>>
{
    internal OptionClass(in T value)
    {
        this.Value = value;
    }

    private OptionClass()
    {
    }

    private NotNull<T> Value { get; }

    internal static OptionClass<T> Null { get; } = new();

    public bool Equals(OptionClass<T> option)
    {
        return this.HasValue == option.HasValue && (!this.HasValue || this.Value.Equals(option.Value));
    }

    public bool HasValue { get; } = true;

    public bool TryGetValue(out NotNull<T> value)
    {
        value = this.Value;
        return this.HasValue;
    }

    public override bool Equals(object obj)
    {
        return obj is OptionClass<T> option && this.Equals(option);
    }

    public override int GetHashCode()
    {
        return this.HasValue ? this.Value.GetHashCode() : 2019994878;
    }
}
