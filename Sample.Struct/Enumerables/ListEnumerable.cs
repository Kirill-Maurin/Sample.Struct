namespace Sample.Struct.Enumerables;

using System.Collections;
using System.Collections.Generic;

public static class ListEnumerable
{
    public static Enumerable<T, List<T>.Enumerator, ListEnumerable<T>> AsStructEnumerable<T>(this List<T> list)
    {
        return new ListEnumerable<T>(list);
    }
}

public readonly struct ListEnumerable<T> : IEnumerable<T, List<T>.Enumerator>
{
    internal ListEnumerable(List<T> unwrap)
    {
        this.Value = unwrap;
    }

    public List<T> Value { get; }

    public List<T>.Enumerator GetEnumerator()
    {
        return this.Value.GetEnumerator();
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
