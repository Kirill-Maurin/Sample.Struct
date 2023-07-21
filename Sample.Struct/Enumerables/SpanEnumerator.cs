namespace Sample.Struct.Enumerables;

using System;
using System.Runtime.CompilerServices;

public ref struct SpanEnumerator<T>
{
    internal SpanEnumerator(Span<T> span)
    {
        this._span = span;
        (this._i, this.Current) = (-1, default);
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
        if ((uint)++this._i >= (uint)this._span.Length)
            return false;
        this.Current = this._span[this._i];
        return true;
    }

    public void Reset()
    {
        throw new NotImplementedException();
    }
}
