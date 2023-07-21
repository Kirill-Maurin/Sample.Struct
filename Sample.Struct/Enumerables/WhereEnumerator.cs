namespace Sample.Struct.Enumerables;

using System;
using System.Collections;
using System.Collections.Generic;

public struct WhereEnumerator<T, TAtor> : IEnumerator<T>
    where TAtor : IEnumerator<T>
{
    internal WhereEnumerator(in TAtor enumerator, Func<T, bool> predicate)
    {
        (_enumerator, _predicate) = (enumerator, predicate);
    }

    private TAtor _enumerator;

    private readonly Func<T, bool> _predicate;

    public T Current => _enumerator.Current;

    object IEnumerator.Current => Current;

    public void Dispose()
    {
    }

    public bool MoveNext()
    {
        do
        {
            if (!_enumerator.MoveNext())
                return false;
        } while (!_predicate(_enumerator.Current));

        return true;
    }

    public void Reset()
    {
        _enumerator.Reset();
    }
}
