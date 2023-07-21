namespace Sample.Struct;

using System;
using System.Collections.Generic;

public readonly struct Key<T, TKey> : IEquatable<Key<T, TKey>>
{
    internal Key(TKey id)
    {
        Value = id;
    }

    public TKey Value { get; }

    public override bool Equals(object obj)
    {
        return obj is Key<T, TKey> id && Equals(id);
    }

    public bool Equals(Key<T, TKey> other)
    {
        return EqualityComparer<TKey>.Default.Equals(Value, other.Value);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(Key<T, TKey> left, Key<T, TKey> right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Key<T, TKey> left, Key<T, TKey> right)
    {
        return !(left == right);
    }
}
