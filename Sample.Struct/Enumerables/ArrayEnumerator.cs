namespace Sample.Struct.Enumerables;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public struct ArrayEnumerator<T> : IEnumerator<T>
{
    internal ArrayEnumerator(T[] array)
    {
        (this._i, this._array, this.Current) = (-1, array, default);
    }

    private readonly T[] _array;

    private int _i;

    public T Current { get; private set; }

    object IEnumerator.Current => this.Current;

    public void Dispose()
    {
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool MoveNext()
    {
        if ((uint)++this._i >= (uint)this._array.Length)
            return false;
        this.Current = this._array[this._i];
        return true;
    }

    public void Reset()
    {
        throw new NotImplementedException();
    }
}
