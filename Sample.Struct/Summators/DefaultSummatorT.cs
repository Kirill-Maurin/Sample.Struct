namespace Sample.Struct.Summators;

using MiscUtil;

public readonly struct DefaultSummatorT<T> : ISummator<T>
{
    public T Add(T left, T right)
    {
        return Operator.Add(left, right);
    }
}
