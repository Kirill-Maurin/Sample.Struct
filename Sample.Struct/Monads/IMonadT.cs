namespace Sample.Struct.Monads;

using System;

public interface IMonad<TMonad, T>
{
    TOutMonad Bind<TOut, TInMonad, TOutMonad>(TInMonad m, Func<T, TOutMonad> action)
        where TOutMonad : IMonad<TMonad, TOut>
        where TInMonad : IMonad<TMonad, TOut>;
}
