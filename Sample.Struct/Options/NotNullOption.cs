using System;

namespace Sample.Struct.Options
{
    public static class NotNullOption
    {
        public static Option<T, NotNullOption<T>> AsOption<T>(this NotNull<T> notNull) where T : class => new Option<T, NotNullOption<T>>(new NotNullOption<T>(notNull));
    }

    public readonly struct NotNullOption<T> : IOption<T>, IEquatable<NotNullOption<T>>
    {
        internal NotNullOption(NotNull<T> value) => Value = value;

        NotNull<T> Value { get; }

        public bool TryGetValue(out NotNull<T> value)
        {
            value = Value;
            return true;
        }

        public bool HasValue => true;

        public override int GetHashCode() => Value.GetHashCode();
        public override string ToString() => Value.ToString();
        public override bool Equals(object obj) => obj is NotNullOption<T> option && Equals(option);
        public bool Equals(NotNullOption<T> other) => Value.Equals(other.Value);
        public static bool operator ==(NotNullOption<T> left, NotNullOption<T> right) => left.Equals(right);
        public static bool operator !=(NotNullOption<T> left, NotNullOption<T> right) => !left.Equals(right);
    }
}
