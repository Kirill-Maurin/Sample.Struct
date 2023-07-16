using System.Runtime.CompilerServices;
using Sample.Struct.Summators;

namespace Sample.Struct.Functions;

public readonly struct Function<T, TIn, TOut>
    where T : IFunc<TIn, TOut>
{
    Function(T value) => _value = value;

    readonly T _value;

    public static implicit operator Function<T, TIn, TOut>(T value) => new(value);
    public static implicit operator T(Function<T, TIn, TOut> value) => value._value;
}

public readonly struct Function<T, TIn, TOut, TOperator>
    where T : IFunc<TIn, TOut>
    where TOperator : ISummator<TOut, TOut>
{
    Function(T value) => Value = value;

    public T Value { get; }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Function<Sum<T, TIn, TOut, TOut, TOperator>, TIn, TOut, TOperator> operator +
    (
        Function<T, TIn, TOut, TOperator> left,
        TOut right
    )
        => new Sum<T, TIn, TOut, TOut, TOperator>(left, right);

    public static implicit operator Function<T, TIn, TOut, TOperator>(T value) => new(value);
    public static implicit operator T(Function<T, TIn, TOut, TOperator> value) => value.Value;
}