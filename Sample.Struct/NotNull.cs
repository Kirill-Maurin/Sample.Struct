using System;
using Sample.Struct.Options;

namespace Sample.Struct
{
    public static class NotNull
    {
        public static NotNull<T> EnsureNotNull<T>(this NotNull<T> value) => value;
        public static NotNull<T> EnsureNotNull<T>([NotNull]this T value) => value.EnsureNotNull(string.Empty);
        public static NotNull<T> EnsureNotNull<T>([NotNull]this T value, string name) 
            => TryCreate(value, out var result) ? result : throw new ArgumentNullException(name);
        public static NotNull<T> AsNotNull<T>(this T value) where T: struct => new NotNull<T>(value);
        public static NotNull<T> AsNotNull<T>(this NotNull<T> value) where T: struct => value;
        public static NotNull<T> CannotBeNull<T>([NotNull]this T reference) where T: class => new NotNull<T>(reference);

        public static bool TryCreate<T>(T value, out NotNull<T> notNull)
        {
            if (value == null)
            {
                notNull = default;
                return false;
            }

            notNull = new NotNull<T>(value);
            return true;
        }
    }

    public readonly struct NotNull<T> : IEquatable<NotNull<T>>, IOption<T>
    {
        internal NotNull([NotNull]T unwrap) => Unwrap = unwrap;

        [NotNull]
        public T Unwrap { get; }

        public override int GetHashCode() => Unwrap.GetHashCode();
        public override string ToString() => $"NotNull {Unwrap}";
        public override bool Equals(object obj) => obj is NotNull<T> notNull && Equals(notNull);
        public bool Equals(NotNull<T> other) => Unwrap.Equals(other.Unwrap);
        public static bool operator ==(NotNull<T> left, NotNull<T> right) => left.Equals(right);
        public static bool operator !=(NotNull<T> left, NotNull<T> right) => !left.Equals(right);
        public static implicit operator T(NotNull<T> t) => t.Unwrap;
        public static implicit operator NotNull<T>(T value) => value.EnsureNotNull();
        public bool TryGetValue(out NotNull<T> value)
        {
            value = this;
            return true;
        }
        public bool HasValue => true;
    }
}
