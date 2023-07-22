namespace Sample.Struct.Functions;

using System;

public static class Delegate
{
    public static Delegate<TIn, TOut> AsStructDelegate<TIn, TOut>(this Func<TIn, TOut> @delegate)
    {
        return new Delegate<TIn, TOut>(@delegate);
    }

    public static FunctionTOut<Delegate<TIn, TOut>, TIn, TOut> AsStruct<TIn, TOut>(this Func<TIn, TOut> @delegate)
    {
        return @delegate.AsStructDelegate();
    }
}
