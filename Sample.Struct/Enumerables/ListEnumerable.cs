using System.Collections;
using System.Collections.Generic;

namespace Sample.Struct.Enumerables
{
    public static class ListEnumerable
    {
        public static Enumerable<T, List<T>.Enumerator, ListEnumerable<T>> AsStructEnumerable<T>(this List<T> list)
            => new Enumerable<T, List<T>.Enumerator, ListEnumerable<T>>(new ListEnumerable<T>(list));        
    }

    public readonly struct ListEnumerable<T> : IEnumerable<T, List<T>.Enumerator>
    {
        internal ListEnumerable(List<T> unwrap) => Value = unwrap;

        public List<T> Value { get; }

        public List<T>.Enumerator GetEnumerator() => Value.GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }    
}