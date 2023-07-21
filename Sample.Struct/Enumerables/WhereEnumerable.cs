namespace Sample.Struct.Enumerables;

using System;
using System.Collections;
using System.Collections.Generic;

public static class WhereEnumerable
{
    public static Enumerable<T, WhereEnumerator<T, TAtor>, WhereEnumerable<T, TAtor, TAble>> Where<T, TAtor, TAble>
        (this in Enumerable<T, TAtor, TAble> enumerable, Func<T, bool> predicate)
        where TAtor : IEnumerator<T>
        where TAble : IEnumerable<T, TAtor>
    {
        return new WhereEnumerable<T, TAtor, TAble>(enumerable, predicate);
    }
}

public readonly struct WhereEnumerable<T, TAtor, TAble> : IEnumerable<T, WhereEnumerator<T, TAtor>>
    where TAtor : IEnumerator<T>
    where TAble : IEnumerable<T, TAtor>
{
    internal WhereEnumerable(in Enumerable<T, TAtor, TAble> unwrap, Func<T, bool> predicate)
    {
        (this.Value, this._predicate) = (unwrap.Value, predicate);
    }

    public TAble Value { get; }

    private readonly Func<T, bool> _predicate;

    public WhereEnumerator<T, TAtor> GetEnumerator()
    {
        return new WhereEnumerator<T, TAtor>(this.Value.GetEnumerator(), this._predicate);
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
