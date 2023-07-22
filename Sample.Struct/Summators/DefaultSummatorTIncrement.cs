namespace Sample.Struct.Summators;

using MiscUtil;

public readonly struct DefaultSummator<T, TIncrement> : ISummator<T, TIncrement>
{
    public T Add(T left, TIncrement right)
    {
        return Operator.AddAlternative(left, right);
    }
}
