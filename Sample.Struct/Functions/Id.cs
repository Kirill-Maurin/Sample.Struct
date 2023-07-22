namespace Sample.Struct.Functions;

using Summators;

public static class Id
{
    public static Function<Id<T>, T, T, TOperator> Function<T, TOperator>()
        where TOperator : struct, ISummator<T, T>
    {
        return default(Id<T>);
    }
}
