using System.Collections;
using Sample.Struct.Summators;

namespace Sample.Struct.Enumerables;

public static class ArrayEnumerable
{
    public static Enumerable<T, ArrayEnumerator<T>, ArrayEnumerable<T>> AsStructEnumerable<T>(this T[] list)
        => new ArrayEnumerable<T>(list);

    public static Linqable<int, ArrayEnumerator<int>, ArrayEnumerable<int>, IntSummator> AsStructLinqable(
        this int[] list)
        => new ArrayEnumerable<int>(list);
}

public readonly struct ArrayEnumerable<T> : IEnumerable<T, ArrayEnumerator<T>>
{
    internal ArrayEnumerable(T[] value) => Value = value;

    public T[] Value { get; }

    public ArrayEnumerator<T> GetEnumerator() => new(Value);

    IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}