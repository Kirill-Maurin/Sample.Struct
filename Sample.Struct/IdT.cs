namespace Sample.Struct;

using System;
using System.Collections.Generic;

public readonly struct Id<T, TKey> : IEquatable<Id<T, TKey>>
    where T : IEntity<TKey>
{
    internal Id(TKey id)
    {
        Value = id;
    }

    public TKey Value { get; }

    public override bool Equals(object obj)
    {
        return obj is Id<T, TKey> id && Equals(id);
    }

    public bool Equals(Id<T, TKey> other)
    {
        return EqualityComparer<TKey>.Default.Equals(Value, other.Value);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(Id<T, TKey> left, Id<T, TKey> right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Id<T, TKey> left, Id<T, TKey> right)
    {
        return !(left == right);
    }
}
