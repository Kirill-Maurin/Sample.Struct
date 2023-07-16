namespace Sample.Struct.Options;

public static class ValueOption
{
    public static ValueOption<T> AsOption<T>(this T? nullable) where T : struct => new(nullable);
    public static ValueOption<T> AsOption<T>(this ValueOption<T> option) where T : struct => option;

    public static T? AsNullable<T>(this ValueOption<T> option) where T : struct =>
        option.TryGetValue(out var v) ? new T?(v) : null;
}

public readonly struct ValueOption<T> : IOption<T>, IEquatable<ValueOption<T>> where T : struct
{
    internal ValueOption(in T? nullable) => (Value, HasValue) = (nullable ?? default, nullable.HasValue);

    public bool TryGetValue(out NotNull<T> value)
    {
        value = new NotNull<T>(Value);
        return HasValue;
    }

    public override bool Equals(object obj) => obj is ValueOption<T> option && Equals(option);
    public override int GetHashCode() => HasValue ? Value.GetHashCode() : 2019994878;
    public override string ToString() => TryGetValue(out var v) ? $"Option {v}" : $"Null<{nameof(T)}>";

    public bool HasValue { get; }
    T Value { get; }

    public bool Equals(ValueOption<T> other) => HasValue == other.HasValue &&
                                                (!HasValue || EqualityComparer<T>.Default.Equals(Value, other.Value));

    public static implicit operator T?(ValueOption<T> option) => option.AsNullable();
    public static implicit operator ValueOption<T>(T? nullable) => nullable.AsOption();

    public static bool operator ==(ValueOption<T> left, ValueOption<T> right) => left.Equals(right);

    public static bool operator !=(ValueOption<T> left, ValueOption<T> right) => !(left == right);
}