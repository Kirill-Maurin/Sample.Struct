using System;

namespace Sample.Struct
{
    public static class OptionClass
    {
        public static OptionClass<T> ToOptionClass<T>(this T value) => value == null ? Null<T>() : new OptionClass<T>(value);
        public static OptionClass<T> Null<T>() => OptionClass<T>.Null;
    }

    public sealed class OptionClass<T> : IEquatable<OptionClass<T>>
    {
        internal OptionClass(T value) => Value = value;
        OptionClass() => HasValue = false;

        public bool HasValue { get; } = true;

        public bool TryGet(out T value)
        {
            value = Value;
            return HasValue;
        }

        T Value { get; }

        internal static OptionClass<T> Null { get; } = new OptionClass<T>();

        public bool Equals(OptionClass<T> option) => HasValue == option.HasValue && (!HasValue || Value.Equals(option.Value));

        public override bool Equals(object obj) => obj is OptionClass<T> option && Equals(option);

        public override int GetHashCode() => HasValue ? Value.GetHashCode() : 2019994878;
    }
}
