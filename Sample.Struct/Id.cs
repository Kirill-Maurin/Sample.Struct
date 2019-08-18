using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Struct
{

    public static class Id
    {
        public static Id<T, TKey> AsId<T, TKey>(this TKey id, T _)
            where T : IEntity<TKey>
            => new Id<T, TKey>(id);
        public static Id<T, TKey> GetId<T, TKey>(this T entity)
            where T : IEntity<TKey>
            => new Id<T, TKey>(entity.Id);
    }

    public readonly struct Id<T, TKey> : IEquatable<Id<T, TKey>>
        where T : IEntity<TKey>
    {
        internal Id(TKey id) => Value = id;
        public TKey Value { get; }

        public override bool Equals(object obj) => obj is Id<T, TKey> id && Equals(id);

        public bool Equals(Id<T, TKey> other) => EqualityComparer<TKey>.Default.Equals(Value, other.Value);

        public override int GetHashCode() => Value.GetHashCode();

        public static bool operator ==(Id<T, TKey> left, Id<T, TKey> right) => left.Equals(right);

        public static bool operator !=(Id<T, TKey> left, Id<T, TKey> right) => !(left == right);
    }
}
