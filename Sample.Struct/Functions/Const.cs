namespace Sample.Struct.Functions;

using System.Runtime.CompilerServices;

public readonly struct Const<TIn, T> : IFunc<TIn, T>
{
    public Const(T value)
    {
        this._value = value;
    }

    private readonly T _value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Invoke(TIn _)
    {
        return this._value;
    }
}
