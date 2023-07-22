namespace Sample.Struct.Functions;

using System.Runtime.CompilerServices;

public readonly struct Id<T> : IFunc<T, T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Invoke(T arg)
    {
        return arg;
    }
}
