using System.Collections;

namespace Sample.Struct.Enumerables;

public static class WhereEnumerable
{
    public static Enumerable<T, WhereEnumerator<T, TAtor>, WhereEnumerable<T, TAtor, TAble>> Where<T, TAtor, TAble>
        (this in Enumerable<T, TAtor, TAble> enumerable, Func<T, bool> predicate)
        where TAtor : IEnumerator<T>
        where TAble : IEnumerable<T, TAtor>
        => new WhereEnumerable<T, TAtor, TAble>(enumerable, predicate);
}

public readonly struct WhereEnumerable<T, TAtor, TAble> : IEnumerable<T, WhereEnumerator<T, TAtor>>
    where TAtor : IEnumerator<T>
    where TAble : IEnumerable<T, TAtor>
{
    internal WhereEnumerable(in Enumerable<T, TAtor, TAble> unwrap, Func<T, bool> predicate)
        => (Value, _predicate) = (unwrap.Value, predicate);

    public TAble Value { get; }

    readonly Func<T, bool> _predicate;

    public WhereEnumerator<T, TAtor> GetEnumerator() => new(Value.GetEnumerator(), _predicate);

    IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}