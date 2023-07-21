namespace Sample.Struct.Enumerables;

using System;
using System.Runtime.CompilerServices;

public ref struct SpanEnumerator<T>
{
    internal SpanEnumerator(Span<T> span)
    {
        _span = span;
        (_i, Current) = (-1, default);
    }

    private readonly Span<T> _span;

    private int _i;

    public T Current { get; private set; }

    public void Dispose()
    {
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool MoveNext()
    {
        if ((uint)++_i >= (uint)_span.Length)
            return false;
        Current = _span[_i];
        return true;
    }

    public void Reset()
    {
        throw new NotImplementedException();
    }
}
