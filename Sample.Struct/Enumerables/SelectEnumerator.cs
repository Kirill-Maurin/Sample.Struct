using System;
using System.Collections;
using System.Collections.Generic;

namespace Sample.Struct.Enumerables
{
    public struct SelectEnumerator<T, TOut, TAtor> : IEnumerator<TOut>
        where TAtor : IEnumerator<T>
    {
        internal SelectEnumerator(in TAtor enumerator, Func<T, TOut> selector)
            => (_enumerator, _selector, Current) = (enumerator, selector, default);

        TAtor _enumerator;

        readonly Func<T, TOut> _selector;

        public TOut Current { get; private set; }

        object IEnumerator.Current => Current;

        public void Dispose() { }

        public bool MoveNext()
        {
            var result = _enumerator.MoveNext();
            if (!result)
                return false;
            Current = _selector(_enumerator.Current);
            return true;
        }

        public void Reset() => _enumerator.Reset();
    }
}