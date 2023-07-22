namespace Sample.Struct.Enumerables;

using System.Collections;
using System.Collections.Generic;
using Summators;

public readonly ref struct Linqable<T, TEnumerator, TEnumerable, TOperator>
    where TEnumerator : IEnumerator<T>
    where TEnumerable : IEnumerable<T, TEnumerator>
    where TOperator : ISummator<T, T>
{
    private Linqable(TEnumerable value)
    {
        Value = value;
    }

    public TEnumerable Value { get; }

    public TEnumerator GetEnumerator()
    {
        return Value.GetEnumerator();
    }

    public static implicit operator Linqable<T, TEnumerator, TEnumerable, TOperator>(TEnumerable value)
    {
        return new Linqable<T, TEnumerator, TEnumerable, TOperator>(value);
    }

    public static implicit operator TEnumerable(Linqable<T, TEnumerator, TEnumerable, TOperator> value)
    {
        return value.Value;
    }
}

public readonly ref struct Enumerable<T, TEnumerator, TEnumerable>
    where TEnumerator : IEnumerator<T>
    where TEnumerable : IEnumerable<T, TEnumerator>
{
    private Enumerable(TEnumerable value)
    {
        Value = value;
    }

    public TEnumerable Value { get; }

    public TEnumerator GetEnumerator()
    {
        return Value.GetEnumerator();
    }

    public static implicit operator Enumerable<T, TEnumerator, TEnumerable>(TEnumerable value)
    {
        return new Enumerable<T, TEnumerator, TEnumerable>(value);
    }

    public static implicit operator TEnumerable(Enumerable<T, TEnumerator, TEnumerable> value)
    {
        return value.Value;
    }
}

public readonly struct Enumerable<T> : IEnumerable<T, IEnumerator<T>>
{
    internal Enumerable(IEnumerable<T> unwrap)
    {
        Value = unwrap;
    }

    public IEnumerable<T> Value { get; }

    public IEnumerator<T> GetEnumerator()
    {
        return Value.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
