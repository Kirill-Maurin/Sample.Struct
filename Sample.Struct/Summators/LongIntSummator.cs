namespace Sample.Struct.Summators;

using System.Runtime.CompilerServices;

public struct LongIntSummator : ISummator<long, int>, IFunc<(long, int), long>, IFunc<long, int, long>
{
    public long Add(long left, int right)
    {
        return left + right;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public long Invoke((long, int) arg)
    {
        return arg.Item1 + arg.Item2;
    }

    public long Invoke(long left, int right)
    {
        return left + right;
    }
}
