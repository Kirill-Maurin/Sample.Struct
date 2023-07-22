namespace Sample.Struct.Functions;

using System.Runtime.CompilerServices;
using Summators;

public readonly struct Function<T, TIn, TOut, TOperator>
    where T : IFunc<TIn, TOut>
    where TOperator : ISummator<TOut, TOut>
{
    private Function(T value)
    {
        this.Value = value;
    }

    public T Value { get; }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Function<SumT<T, TIn, TOut, TOut, TOperator>, TIn, TOut, TOperator> operator +
    (
        Function<T, TIn, TOut, TOperator> left,
        TOut right
    )
    {
        return new SumT<T, TIn, TOut, TOut, TOperator>(left, right);
    }

    public static implicit operator Function<T, TIn, TOut, TOperator>(T value)
    {
        return new Function<T, TIn, TOut, TOperator>(value);
    }

    public static implicit operator T(Function<T, TIn, TOut, TOperator> value)
    {
        return value.Value;
    }
}
