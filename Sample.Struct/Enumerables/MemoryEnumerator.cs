namespace Sample.Struct.Enumerables;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public struct MemoryEnumerator<T> : IEnumerator<T>
{
    internal MemoryEnumerator(Memory<T> memory)
    {
        (_i, _memory, Current) = (-1, memory, default);
    }

    private readonly Memory<T> _memory;

    private int _i;

    public T Current { get; private set; }

    object IEnumerator.Current => Current;

    public void Dispose()
    {
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool MoveNext()
    {
        if ((uint)++_i >= (uint)_memory.Length)
            return false;
        Current = _memory.Span[_i];
        return true;
    }

    public void Reset()
    {
        throw new NotImplementedException();
    }
}
