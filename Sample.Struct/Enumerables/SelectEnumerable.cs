namespace Sample.Struct.Enumerables;

using System;
using System.Collections;
using System.Collections.Generic;
using Functions;
using Summators;

public static class SelectEnumerable
{
    public static
        Enumerable<TOut, SelectEnumerator<int, TOut, TAtor, TSelector>,
            SelectEnumerable<int, TOut, TAtor, TAble, TSelector>> Select<TAtor, TAble, TSelector, TOut, TOperator>
        (this in Linqable<int, TAtor, TAble, TOperator> enumerable,
            Func<Function<Id<int>, int, int, TOperator>, Function<TSelector, int, TOut, TOperator>> selector)
        where TAtor : IEnumerator<int>
        where TAble : IEnumerable<int, TAtor>
        where TSelector : IFunc<int, TOut>
        where TOperator : struct, ISummator<int, int>, ISummator<TOut, TOut>
    {
        return new SelectEnumerable<int, TOut, TAtor, TAble, TSelector>(enumerable.Value,
            selector(Id.Function<int, TOperator>()));
    }

    public static
        Enumerable<TOut, SelectEnumerator<T, TOut, TAtor, Delegate<T, TOut>>,
            SelectEnumerable<T, TOut, TAtor, TAble, Delegate<T, TOut>>> Select<T, TOut, TAtor, TAble>
        (this in Enumerable<T, TAtor, TAble> enumerable, Func<T, TOut> selector)
        where TAtor : IEnumerator<T>
        where TAble : IEnumerable<T, TAtor>
    {
        return enumerable.Select(selector.AsStruct());
    }

    public static
        Enumerable<TOut, SelectEnumerator<T, TOut, TAtor, TSelector>,
            SelectEnumerable<T, TOut, TAtor, TAble, TSelector>> Select<T, TOut, TAtor, TAble, TSelector>
        (this in Enumerable<T, TAtor, TAble> enumerable, Function<TSelector, T, TOut> selector)
        where TAtor : IEnumerator<T>
        where TAble : IEnumerable<T, TAtor>
        where TSelector : IFunc<T, TOut>
    {
        return new SelectEnumerable<T, TOut, TAtor, TAble, TSelector>(enumerable, selector);
    }
}

public readonly struct
    SelectEnumerable<T, TOut, TAtor, TAble, TSelector> : IEnumerable<TOut, SelectEnumerator<T, TOut, TAtor, TSelector>>
    where TAtor : IEnumerator<T>
    where TAble : IEnumerable<T, TAtor>
    where TSelector : IFunc<T, TOut>
{
    internal SelectEnumerable(in Enumerable<T, TAtor, TAble> unwrap, TSelector selector)
    {
        (this.Value, this._selector) = (unwrap.Value, selector);
    }

    public TAble Value { get; }

    private readonly TSelector _selector;

    public SelectEnumerator<T, TOut, TAtor, TSelector> GetEnumerator()
    {
        return new SelectEnumerator<T, TOut, TAtor, TSelector>(this.Value.GetEnumerator(), this._selector);
    }

    IEnumerator<TOut> IEnumerable<TOut>.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
