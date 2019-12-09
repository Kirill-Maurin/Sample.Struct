using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Struct.Monads
{
    public interface IMonad<T>
    { }
     
    public interface IMonad<TMonad, T>
    {
        TOutMonad Bind<TOut, TInMonad, TOutMonad>(TInMonad m, Func<T, TOutMonad> action) 
            where TOutMonad : IMonad<TMonad, TOut>
            where TInMonad: IMonad<TMonad, TOut>; 
    }
}
