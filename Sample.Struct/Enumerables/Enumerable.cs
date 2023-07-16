using System.Collections;
using Sample.Struct.Summators;

namespace Sample.Struct.Enumerables;

public readonly ref struct Linqable<T, TEnumerator, TEnumerable, TOperator>
    where TEnumerator : IEnumerator<T>
    where TEnumerable : IEnumerable<T, TEnumerator>
    where TOperator : ISummator<T, T>
{
    Linqable(TEnumerable value) => Value = value;

    public TEnumerable Value { get; }

    public TEnumerator GetEnumerator() => Value.GetEnumerator();

    public static implicit operator Linqable<T, TEnumerator, TEnumerable, TOperator>(TEnumerable value) => new(value);
    public static implicit operator TEnumerable(Linqable<T, TEnumerator, TEnumerable, TOperator> value) => value.Value;
}

public readonly ref struct Enumerable<T, TEnumerator, TEnumerable>
    where TEnumerator : IEnumerator<T>
    where TEnumerable : IEnumerable<T, TEnumerator>
{
    Enumerable(TEnumerable value) => Value = value;

    public TEnumerable Value { get; }

    public TEnumerator GetEnumerator() => Value.GetEnumerator();

    public static implicit operator Enumerable<T, TEnumerator, TEnumerable>(TEnumerable value) => new(value);
    public static implicit operator TEnumerable(Enumerable<T, TEnumerator, TEnumerable> value) => value.Value;
}

public readonly struct Enumerable<T> : IEnumerable<T, IEnumerator<T>>
{
    internal Enumerable(IEnumerable<T> unwrap) => Value = unwrap;

    public IEnumerable<T> Value { get; }

    public IEnumerator<T> GetEnumerator() => Value.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}