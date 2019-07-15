using System;

namespace Sample.Struct.Options
{
    public readonly struct Null<T> : IEquatable<Null<T>>, IOption<T>
    {
        internal static Option<T, Null<T>> Instance = new Option<T, Null<T>>();
        public override int GetHashCode() => 0;
        public override string ToString() => $"Null<{nameof(T)}>";
        public override bool Equals(object obj) => obj is Null<T> notNull;
        public bool Equals(Null<T> other) => true;
        public static bool operator ==(Null<T> left, Null<T> right) => true;
        public static bool operator !=(Null<T> left, Null<T> right) => false;
        public bool TryGetValue(out NotNull<T> value)
        {
            value = default;
            return false;
        }
        public bool HasValue => false;
    }    
}