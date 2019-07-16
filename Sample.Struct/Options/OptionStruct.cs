using System;

namespace Sample.Struct.Options
{
    public static class OptionStruct
    {
        public static OptionStruct<T> ToOptionStruct<T>(this T value) => value == null ? Null<T>() : new OptionStruct<T>(value);
        public static OptionStruct<T> Null<T>() => OptionStruct<T>.Null;
    }

    public readonly struct OptionStruct<T> : IOption<T>, IEquatable<OptionStruct<T>>
    {
        internal OptionStruct(in T value) => (HasValue, Value) = (true, value);

        public bool HasValue { get; }

        public bool TryGetValue(out NotNull<T> value)
        {
            value = Value;
            return HasValue;
        }

        NotNull<T> Value { get; }

        internal static OptionStruct<T> Null { get; } = new OptionStruct<T>();

        public bool Equals(OptionStruct<T> option) => HasValue == option.HasValue && (!HasValue || Value.Equals(option.Value));

        public override bool Equals(object obj) => obj is OptionStruct<T> option && Equals(option);

        public override int GetHashCode() => HasValue ? Value.GetHashCode() : 2019994878;

        public static bool operator ==(OptionStruct<T> left, OptionStruct<T> right) => left.Equals(right);

        public static bool operator !=(OptionStruct<T> left, OptionStruct<T> right) => !(left == right);
    }
}
