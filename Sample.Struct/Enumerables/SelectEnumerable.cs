using System;
using System.Collections;
using System.Collections.Generic;

namespace Sample.Struct.Enumerables
{
    public static class SelectEnumerable
    {
        public static Enumerable<TOut, SelectEnumerator<T, TOut, TAtor>, SelectEnumerable<T, TOut, TAtor, TAble>> Select<T, TOut, TAtor, TAble>
            (this in Enumerable<T, TAtor, TAble> enumerable, Func<T, TOut> selector)
            where TAtor : IEnumerator<T>
            where TAble : IEnumerable<T, TAtor>
            => new Enumerable<TOut, SelectEnumerator<T, TOut, TAtor>, SelectEnumerable<T, TOut, TAtor, TAble>>
                (new SelectEnumerable<T, TOut, TAtor, TAble>(enumerable, selector));
    }

    public readonly struct SelectEnumerable<T, TOut, TAtor, TAble> : IEnumerable<TOut, SelectEnumerator<T, TOut, TAtor>>
        where TAtor : IEnumerator<T>
        where TAble : IEnumerable<T, TAtor>
    {
        internal SelectEnumerable(in Enumerable<T, TAtor, TAble> unwrap, Func<T, TOut> selector)
            => (Value, _selector) = (unwrap, selector);

        public Enumerable<T, TAtor, TAble> Value { get; }

        readonly Func<T, TOut> _selector;

        public SelectEnumerator<T, TOut, TAtor> GetEnumerator()
            => new SelectEnumerator<T, TOut, TAtor>(Value.GetEnumerator(), _selector);

        IEnumerator<TOut> IEnumerable<TOut>.GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}