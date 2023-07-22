namespace Sample.Struct.Indexables;

using System.Collections.Generic;

public struct ListIndexable<T> : IIndexable<T, int>
{
    internal ListIndexable(List<T> value)
    {
        this.Value = value;
    }

    public List<T> Value { get; }

    public T this[int index] => this.Value[index];

    public int Count => this.Value.Count;
}
