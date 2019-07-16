using System;
using System.Collections.Generic;

namespace Sample.Struct
{
    public static class Key
    {
        public static Key<T, TKey> AsKey<T, TKey>(this TKey id, T _)
            => new Key<T, TKey>(id);
    }

    public readonly struct Key<T, TKey> : IEquatable<Key<T, TKey>>
    {
        internal Key(TKey id) => Unwrap = id;

        public TKey Unwrap { get; }

        public override bool Equals(object obj) => obj is Key<T, TKey> id && Equals(id);

        public bool Equals(Key<T, TKey> other) => EqualityComparer<TKey>.Default.Equals(Unwrap, other.Unwrap);

        public override int GetHashCode() => Unwrap.GetHashCode();

        public static bool operator ==(Key<T, TKey> left, Key<T, TKey> right) => left.Equals(right);

        public static bool operator !=(Key<T, TKey> left, Key<T, TKey> right) => !(left == right);
    }
}
