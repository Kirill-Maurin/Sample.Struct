namespace Sample.Struct.Enumerables;

using System.Collections;
using System.Collections.Generic;

public static class ValueCollectionEnumerable
{
    public static Enumerable<T, Dictionary<TKey, T>.ValueCollection.Enumerator, ValueCollectionEnumerable<TKey, T>>
        AsStructEnumerable<TKey, T>
        (this Dictionary<TKey, T>.ValueCollection keys)
    {
        return new ValueCollectionEnumerable<TKey, T>(keys);
    }
}

public readonly struct
    ValueCollectionEnumerable<TKey, T> : IEnumerable<T, Dictionary<TKey, T>.ValueCollection.Enumerator>
{
    internal ValueCollectionEnumerable(Dictionary<TKey, T>.ValueCollection unwrap)
    {
        Value = unwrap;
    }

    public Dictionary<TKey, T>.ValueCollection Value { get; }

    public Dictionary<TKey, T>.ValueCollection.Enumerator GetEnumerator()
    {
        return Value.GetEnumerator();
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        return GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
