using System.Collections;
using System.Collections.Generic;

namespace Sample.Struct.Enumerables
{
    public static class DictionaryEnumerable
    {
        public static Enumerable<KeyValuePair<TKey, T>, Dictionary<TKey, T>.Enumerator, DictionaryEnumerable<TKey, T>> AsStructEnumerable<TKey, T>
            (this Dictionary<TKey, T> dictionary)
            => new Enumerable<KeyValuePair<TKey, T>, Dictionary<TKey, T>.Enumerator, DictionaryEnumerable<TKey, T>>
                (new DictionaryEnumerable<TKey,T>(dictionary));
    }

    public readonly struct DictionaryEnumerable<TKey, T> : IEnumerable<KeyValuePair<TKey, T>, Dictionary<TKey, T>.Enumerator>
    {
        internal DictionaryEnumerable(Dictionary<TKey, T> unwrap) => Unwrap = unwrap;

        public Dictionary<TKey, T> Unwrap { get; }

        public Dictionary<TKey, T>.Enumerator GetEnumerator() => Unwrap.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        IEnumerator<KeyValuePair<TKey, T>> IEnumerable<KeyValuePair<TKey, T>>.GetEnumerator() => GetEnumerator();
    }
}