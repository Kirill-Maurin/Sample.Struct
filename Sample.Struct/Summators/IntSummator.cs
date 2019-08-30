namespace Sample.Struct.Summators
{
    public readonly struct IntSummator : ISummator<int>
    {
        public int Add(int left, int right) => left + right;
    }
}
