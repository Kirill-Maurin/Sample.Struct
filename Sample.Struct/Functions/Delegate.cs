namespace Sample.Struct.Functions;

public static class Delegate
{
    public static Delegate<TIn, TOut> AsStructDelegate<TIn, TOut>(this Func<TIn, TOut> @delegate) => new(@delegate);

    public static Function<Delegate<TIn, TOut>, TIn, TOut> AsStruct<TIn, TOut>(this Func<TIn, TOut> @delegate)
        => @delegate.AsStructDelegate();
}

public readonly struct Delegate<TIn, T> : IFunc<TIn, T>
{
    internal Delegate(Func<TIn, T> @delegate) => _delegate = @delegate;

    readonly Func<TIn, T> _delegate;

    public T Invoke(TIn arg) => _delegate(arg);
}