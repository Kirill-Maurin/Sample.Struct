namespace Sample.Struct.Summators;

using System.Runtime.CompilerServices;

public readonly struct IntSummator : ISummator<int>, ISummator<int, int>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int Add(int left, int right)
    {
        return left + right;
    }
}
