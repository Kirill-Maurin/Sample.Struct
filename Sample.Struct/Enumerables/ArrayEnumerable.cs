using System.Collections;
using System.Collections.Generic;

namespace Sample.Struct.Enumerables
{
    public static class ArrayEnumerable
    {
        public static Enumerable<T, ArrayEnumerator<T>, ArrayEnumerable<T>> AsStructEnumerable<T>(this T[] list)
            => new Enumerable<T, ArrayEnumerator<T>, ArrayEnumerable<T>>(new ArrayEnumerable<T>(list));        
    }

    public readonly struct ArrayEnumerable<T> : IEnumerable<T, ArrayEnumerator<T>>
    {
        internal ArrayEnumerable(T[] unwrap) => Value = unwrap;

        public T[] Value { get; }

        public ArrayEnumerator<T> GetEnumerator() => new ArrayEnumerator<T>(Value);

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}