namespace Sample.Struct.Enumerables;

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public struct SelectEnumerator<T, TOut, TAtor, TSelector> : IEnumerator<TOut>
    where TAtor : IEnumerator<T>
    where TSelector : IFunc<T, TOut>
{
    internal SelectEnumerator(in TAtor enumerator, TSelector selector)
    {
        (_enumerator, _selector, Current) = (enumerator, selector, default);
    }

    private TAtor _enumerator;

    private readonly TSelector _selector;

    public TOut Current { get; private set; }

    object IEnumerator.Current => Current;

    public void Dispose()
    {
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool MoveNext()
    {
        if (!_enumerator.MoveNext())
            return false;
        TSelector s = _selector;
        Current = s.Invoke(_enumerator.Current);
        return true;
    }

    public void Reset()
    {
        _enumerator.Reset();
    }
}
