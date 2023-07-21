namespace Sample.Struct.Enumerables;

using System;
using System.Collections;
using System.Collections.Generic;

public struct WhereEnumerator<T, TAtor> : IEnumerator<T>
    where TAtor : IEnumerator<T>
{
    internal WhereEnumerator(in TAtor enumerator, Func<T, bool> predicate)
    {
        (this._enumerator, this._predicate) = (enumerator, predicate);
    }

    private TAtor _enumerator;

    private readonly Func<T, bool> _predicate;

    public T Current => this._enumerator.Current;

    object IEnumerator.Current => this.Current;

    public void Dispose()
    {
    }

    public bool MoveNext()
    {
        do
        {
            if (!this._enumerator.MoveNext())
                return false;
        } while (!this._predicate(this._enumerator.Current));

        return true;
    }

    public void Reset()
    {
        this._enumerator.Reset();
    }
}
