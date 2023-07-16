namespace Sample.Struct.Indexables;

public static class ListIndexable
{
    public static Indexable<T, int, ListIndexable<T>> AsIndexable<T>(this List<T> list) =>
        new(new ListIndexable<T>(list));
}

public struct ListIndexable<T> : IIndexable<T, int>
{
    internal ListIndexable(List<T> value) => Value = value;

    public List<T> Value { get; }

    public T this[int index] => Value[index];

    public int Count => Value.Count;
}