using System;

namespace Sample.Struct.Options
{
    public static class NotNullOption
    {
        public static Option<T, NotNullOption<T>> AsOption<T>(this NotNull<T> notNull) where T : class => new Option<T, NotNullOption<T>>(new NotNullOption<T>(notNull));
    }

    public readonly struct NotNullOption<T> : IOption<T>, IEquatable<NotNullOption<T>>
    {
        internal NotNullOption(NotNull<T> value) => Unwrap = value;

        NotNull<T> Unwrap { get; }

        public bool TryGetValue(out NotNull<T> value)
        {
            value = Unwrap;
            return true;
        }

        public bool HasValue => true;

        public override int GetHashCode() => Unwrap.GetHashCode();
        public override string ToString() => Unwrap.ToString();
        public override bool Equals(object obj) => obj is NotNullOption<T> option && Equals(option);
        public bool Equals(NotNullOption<T> other) => Unwrap.Equals(other.Unwrap);
        public static bool operator ==(NotNullOption<T> left, NotNullOption<T> right) => left.Equals(right);
        public static bool operator !=(NotNullOption<T> left, NotNullOption<T> right) => !left.Equals(right);
    }
}
