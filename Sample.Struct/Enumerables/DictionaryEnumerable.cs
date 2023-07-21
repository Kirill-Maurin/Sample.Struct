namespace Sample.Struct.Enumerables;

using System.Collections;
using System.Collections.Generic;

public static class DictionaryEnumerable
{
    public static Enumerable<KeyValuePair<TKey, T>, Dictionary<TKey, T>.Enumerator, DictionaryEnumerable<TKey, T>>
        AsStructEnumerable<TKey, T>
        (this Dictionary<TKey, T> dictionary)
    {
        return new DictionaryEnumerable<TKey, T>(dictionary);
    }
}

public readonly struct
    DictionaryEnumerable<TKey, T> : IEnumerable<KeyValuePair<TKey, T>, Dictionary<TKey, T>.Enumerator>
{
    internal DictionaryEnumerable(Dictionary<TKey, T> unwrap)
    {
        Value = unwrap;
    }

    public Dictionary<TKey, T> Value { get; }

    public Dictionary<TKey, T>.Enumerator GetEnumerator()
    {
        return Value.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    IEnumerator<KeyValuePair<TKey, T>> IEnumerable<KeyValuePair<TKey, T>>.GetEnumerator()
    {
        return GetEnumerator();
    }
}
