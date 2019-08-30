namespace Sample.Struct.Summators
{
    public readonly struct DefaultSummator<T> : ISummator<T>
    {
        public T Add(T left, T right) => MiscUtil.Operator.Add(left, right);
    }

    public readonly struct DefaultSummator<T, TIncrement> : ISummator<T, TIncrement>
    {
        public T Add(T left, TIncrement right) => MiscUtil.Operator.AddAlternative(left, right);
    }
}