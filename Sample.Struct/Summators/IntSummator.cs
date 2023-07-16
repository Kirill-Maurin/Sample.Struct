using System.Runtime.CompilerServices;

namespace Sample.Struct.Summators;

public readonly struct IntSummator : ISummator<int>, ISummator<int, int>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int Add(int left, int right) => left + right;
}