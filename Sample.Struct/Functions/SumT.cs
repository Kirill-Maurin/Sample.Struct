namespace Sample.Struct.Functions;

using System.Runtime.CompilerServices;
using Summators;

public readonly struct SumT<T, TIn, TOut, TOut2, TSummator> : IFunc<TIn, TOut>
    where T : IFunc<TIn, TOut>
    where TSummator : ISummator<TOut, TOut2>
{
    public SumT(T left, TOut2 right)
    {
        this._left = left;
        this._right = right;
    }

    private readonly T _left;
    private readonly TOut2 _right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public TOut Invoke(TIn arg)
    {
        var c = default(TSummator);
        return c.Add(this._left.Invoke(arg), this._right);
    }
}
