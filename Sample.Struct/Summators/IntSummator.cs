namespace Sample.Struct.Summators
{
    public struct IntSummator : ISummator<int>
    {
        public int Add(int left, int right) => left + right;
    }

    public struct IntIncrementalSummator : ISummator<long, int>
    {
        public long Add(long left, int right) => left + right;
    }

    public struct IntCheckedSummator : ISummator<int>
    {
        public int Add(int left, int right) { checked { return left + right; } }
    }
}
