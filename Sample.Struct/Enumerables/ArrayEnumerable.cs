namespace Sample.Struct.Enumerables;

using System.Collections;
using System.Collections.Generic;
using Summators;

public static class ArrayEnumerable
{
    public static Enumerable<T, ArrayEnumerator<T>, ArrayEnumerable<T>> AsStructEnumerable<T>(this T[] list)
    {
        return new ArrayEnumerable<T>(list);
    }

    public static Linqable<int, ArrayEnumerator<int>, ArrayEnumerable<int>, IntSummator> AsStructLinqable(
        this int[] list)
    {
        return new ArrayEnumerable<int>(list);
    }
}

public readonly struct ArrayEnumerable<T> : IEnumerable<T, ArrayEnumerator<T>>
{
    internal ArrayEnumerable(T[] value)
    {
        this.Value = value;
    }

    public T[] Value { get; }

    public ArrayEnumerator<T> GetEnumerator()
    {
        return new ArrayEnumerator<T>(this.Value);
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
