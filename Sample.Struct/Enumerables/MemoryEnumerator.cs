namespace Sample.Struct.Enumerables;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public struct MemoryEnumerator<T> : IEnumerator<T>
{
    internal MemoryEnumerator(Memory<T> memory)
    {
        (this._i, this._memory, this.Current) = (-1, memory, default);
    }

    private readonly Memory<T> _memory;

    private int _i;

    public T Current { get; private set; }

    object IEnumerator.Current => this.Current;

    public void Dispose()
    {
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool MoveNext()
    {
        if ((uint)++this._i >= (uint)this._memory.Length)
            return false;
        this.Current = this._memory.Span[this._i];
        return true;
    }

    public void Reset()
    {
        throw new NotImplementedException();
    }
}
