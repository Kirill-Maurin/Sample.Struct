namespace Sample.Struct.Enumerables;

using System.Collections;
using System.Collections.Generic;

public static class KeyCollectionEnumerable
{
    public static Enumerable<TKey, Dictionary<TKey, T>.KeyCollection.Enumerator, KeyCollectionEnumerable<TKey, T>>
        AsStructEnumerable<TKey, T>
        (this Dictionary<TKey, T>.KeyCollection keys)
    {
        return new KeyCollectionEnumerable<TKey, T>(keys);
    }
}

public readonly struct
    KeyCollectionEnumerable<TKey, T> : IEnumerable<TKey, Dictionary<TKey, T>.KeyCollection.Enumerator>
{
    internal KeyCollectionEnumerable(Dictionary<TKey, T>.KeyCollection unwrap)
    {
        this.Value = unwrap;
    }

    public Dictionary<TKey, T>.KeyCollection Value { get; }

    public Dictionary<TKey, T>.KeyCollection.Enumerator GetEnumerator()
    {
        return this.Value.GetEnumerator();
    }

    IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
