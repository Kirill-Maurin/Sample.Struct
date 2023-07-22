namespace Sample.Struct.Functions;

using System.Runtime.CompilerServices;
using Summators;

public readonly struct Sum<TLeft, TRight, TIn, TOut, TOut2, TSummator> : IFunc<TIn, TOut>
    where TLeft : IFunc<TIn, TOut>
    where TRight : IFunc<TIn, TOut2>
    where TSummator : ISummator<TOut, TOut2>
{
    public Sum(TLeft left, TRight right)
    {
        this._left = left;
        this._right = right;
    }

    private readonly TLeft _left;
    private readonly TRight _right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public TOut Invoke(TIn arg)
    {
        var c = default(TSummator);
        return c.Add(this._left.Invoke(arg), this._right.Invoke(arg));
    }
}
