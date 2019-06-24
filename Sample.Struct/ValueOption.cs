using System;
using System.Collections.Generic;

namespace Sample.Struct
{
    public static class ValueOption
    {
        public static ValueOption<T> AsOption<T>(this T? nullable) where T: struct => new ValueOption<T>(nullable);
        public static ValueOption<T> AsOption<T>(this ValueOption<T> option) where T: struct => option;
        public static ValueOption<T> AsNullable<T>(this ValueOption<T> option) where T: struct => option.TryGetValue(out var v) ? new Nullable<T>(v) : null;
    }

    public struct ValueOption<T> : IOption<T>, IEquatable<ValueOption<T>> where T: struct
    {
        internal ValueOption(T? nullable) => (Value, HasValue) = (nullable.HasValue ? nullable.Value : default, nullable.HasValue);

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

        public bool Equals(ValueOption<T> other) => HasValue == other.HasValue && (!HasValue || EqualityComparer<T>.Default.Equals(Value, other.Value));

        public static implicit operator T?(ValueOption<T> option) => option.AsNullable();
        public static implicit operator ValueOption<T>(T? nullable) => nullable.AsOption();
    }
}
