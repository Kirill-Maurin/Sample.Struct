using System.Runtime.CompilerServices;

namespace Sample.Struct.Functions
{
    public readonly struct Const<TIn, T> : IFunc<TIn, T>
    {
        public Const(T value) => _value = value;

        readonly T _value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T Invoke(TIn _) => _value;
    }
}
