using System.Collections;
using System.Collections.Generic;

namespace Sample.Struct.Enumerables
{
    public static class KeyCollectionEnumerable
    {
        public static Enumerable<TKey, Dictionary<TKey, T>.KeyCollection.Enumerator, KeyCollectionEnumerable<TKey, T>> AsStructEnumerable<TKey, T>
            (this Dictionary<TKey, T>.KeyCollection keys)
            => new KeyCollectionEnumerable<TKey,T>(keys);
    }

    public readonly struct KeyCollectionEnumerable<TKey, T> : IEnumerable<TKey, Dictionary<TKey, T>.KeyCollection.Enumerator>
    {
        internal KeyCollectionEnumerable(Dictionary<TKey, T>.KeyCollection unwrap) => Value = unwrap;

        public Dictionary<TKey, T>.KeyCollection Value { get; }

        public Dictionary<TKey, T>.KeyCollection.Enumerator GetEnumerator() => Value.GetEnumerator();

        IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}