namespace Sample.Struct.Summators
{
    public struct IntCheckedSummator : ISummator<int>
    {
        public int Add(int left, int right) { checked { return left + right; } }
    }
}
