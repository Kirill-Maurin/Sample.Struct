using System.Collections.Generic;

namespace Sample.Struct.Indexables
{
    public static class ListIndexable
    {
        public static Indexable<T, int, ListIndexable<T>> AsIndexable<T>(this List<T> list)
            => new Indexable<T, int, ListIndexable<T>>(new ListIndexable<T>(list));
    }

    public struct ListIndexable<T> : IIndexable<T, int>
    {
        internal ListIndexable(List<T> value) => Unwrap = value;

        public List<T> Unwrap { get; }

        public T this[int index] => Unwrap[index];

        public int Count => Unwrap.Count;
    }

}
