using System.Runtime.CompilerServices;
using Sample.Struct.Summators;

namespace Sample.Struct.Functions;

public static class Id
{
    public static Function<Id<T>, T, T, TOperator> Function<T, TOperator>()
        where TOperator : struct, ISummator<T, T>
        => default(Id<T>);
}

public readonly struct Id<T> : IFunc<T, T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Invoke(T arg) => arg;
}