using System;
using System.Runtime.CompilerServices;

namespace Sample.Struct
{
    public static class NotNull
    {
        public static NotNull<T> ToNotNull<T>(this T value) where T : class =>
            TryCreate(value, out var result) ? result : throw new ArgumentNullException();

        public static NotNull<T> ToValNotNull<T>(this T? value) where T : struct =>
            TryValCreate(value, out var result) ? result : throw new ArgumentNullException();

        public static bool TryCreate<T>(T value, out NotNull<T> notNull) where T : class
        {
            if (value == null)
            {
                notNull = default;
                return false;
            }

            notNull = new NotNull<T>(value);
            return true;
        }

        public static bool TryValCreate<T>(T? value, out NotNull<T> notNull) where T : struct
        {
            if (!value.HasValue)
            {
                notNull = default;
                return false;
            }

            notNull = new NotNull<T>(value.Value);
            return true;
        }
    }

    public readonly struct NotNull<T> : IEquatable<NotNull<T>>
    {
        internal NotNull(T unwrap) => Unwrap = unwrap;

        public T Unwrap { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; }

        public override int GetHashCode() => Unwrap.GetHashCode();
        public override string ToString() => $"NotNull {Unwrap}";
        public override bool Equals(object obj) => obj is NotNull<T> notNull && Equals(notNull);
        public bool Equals(NotNull<T> other) => Unwrap.Equals(other.Unwrap);
        public static bool operator ==(NotNull<T> left, NotNull<T> right) => left.Equals(right);
        public static bool operator !=(NotNull<T> left, NotNull<T> right) => !left.Equals(right);
    }
}
