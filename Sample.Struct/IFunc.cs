﻿namespace Sample.Struct;

public interface IFunc<in TIn, out T>
{
    T Invoke(TIn arg);
}

public interface IFunc<in TLeft, TRight, out T>
{
    T Invoke(TLeft left, TRight right);
}
