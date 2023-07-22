namespace Sample.Struct.Enumerables;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public struct ArrayEnumerator<T> : IEnumerator<T>
{
    internal ArrayEnumerator(T[] array)
    {
        (_i, _array, Current) = (-1, array, default);
    }

    private readonly T[] _array;

    private int _i;

    public T Current { get; private set; }

    object IEnumerator.Current => Current;

    public void Dispose()
    {
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool MoveNext()
    {
        if ((uint)++_i >= (uint)_array.Length)
            return false;
        Current = _array[_i];
        return true;
    }

    public void Reset()
    {
        throw new NotImplementedException();
    }
}
