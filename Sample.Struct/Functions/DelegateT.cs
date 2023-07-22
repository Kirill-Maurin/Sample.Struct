namespace Sample.Struct.Functions;

using System;

public readonly struct Delegate<TIn, T> : IFunc<TIn, T>
{
    internal Delegate(Func<TIn, T> @delegate)
    {
        this._delegate = @delegate;
    }

    private readonly Func<TIn, T> _delegate;

    public T Invoke(TIn arg)
    {
        return this._delegate(arg);
    }
}
