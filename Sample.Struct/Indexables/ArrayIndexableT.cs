namespace Sample.Struct.Indexables;

public struct ArrayIndexable<T> : IIndexable<T, int>
{
    internal ArrayIndexable(T[] value)
    {
        this.Value = value;
    }

    public T[] Value { get; }

    public T this[int index] => this.Value[index];

    public int Count => this.Value.Length;

    public static implicit operator ArrayIndexable<T>(T[] array)
    {
        return new ArrayIndexable<T>(array);
    }

    public static implicit operator T[](ArrayIndexable<T> value)
    {
        return value.Value;
    }
}
