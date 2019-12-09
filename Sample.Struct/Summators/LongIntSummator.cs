using System.Runtime.CompilerServices;

namespace Sample.Struct.Summators
{
    public struct LongIntSummator : ISummator<long, int>, IFunc<(long, int), long>, IFunc<long, int, long>
    {
        public long Add(long left, int right) => left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long Invoke((long, int) arg) => arg.Item1 + arg.Item2;

        public long Invoke(long left, int right) => left + right;
    }
}
