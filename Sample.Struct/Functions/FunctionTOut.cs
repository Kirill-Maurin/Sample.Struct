namespace Sample.Struct.Functions;

public readonly struct FunctionTOut<T, TIn, TOut>
    where T : IFunc<TIn, TOut>
{
    private FunctionTOut(T value)
    {
        this._value = value;
    }

    private readonly T _value;

    public static implicit operator FunctionTOut<T, TIn, TOut>(T value)
    {
        return new FunctionTOut<T, TIn, TOut>(value);
    }

    public static implicit operator T(FunctionTOut<T, TIn, TOut> value)
    {
        return value._value;
    }
}
