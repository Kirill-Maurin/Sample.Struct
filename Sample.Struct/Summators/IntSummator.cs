namespace Sample.Struct.Summators
{
    public struct IntSummator : ISummator<int>
    {
        public int Add(int left, int right) => left + right;
    }
}
