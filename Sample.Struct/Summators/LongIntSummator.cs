namespace Sample.Struct.Summators
{
    public struct LongIntSummator : ISummator<long, int>
    {
        public long Add(long left, int right) => left + right;
    }
}
