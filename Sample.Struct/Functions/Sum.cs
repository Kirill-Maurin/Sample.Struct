using System.Runtime.CompilerServices;
using Sample.Struct.Summators;

namespace Sample.Struct.Functions;

public readonly struct Sum<TLeft, TRight, TIn, TOut, TOut2, TSummator> : IFunc<TIn, TOut>
    where TLeft : IFunc<TIn, TOut>
    where TRight : IFunc<TIn, TOut2>
    where TSummator : ISummator<TOut, TOut2>
{
    public Sum(TLeft left, TRight right)
    {
        _left = left;
        _right = right;
    }

    readonly TLeft _left;
    readonly TRight _right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public TOut Invoke(TIn arg)
    {
        var c = default(TSummator);
        return c.Add(_left.Invoke(arg), _right.Invoke(arg));
    }
}

public readonly struct Sum<T, TIn, TOut, TOut2, TSummator> : IFunc<TIn, TOut>
    where T : IFunc<TIn, TOut>
    where TSummator : ISummator<TOut, TOut2>
{
    public Sum(T left, TOut2 right)
    {
        _left = left;
        _right = right;
    }

    readonly T _left;
    readonly TOut2 _right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public TOut Invoke(TIn arg)
    {
        var c = default(TSummator);
        return c.Add(_left.Invoke(arg), _right);
    }
}