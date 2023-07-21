namespace Sample.Struct;

using System.Collections.Generic;
using Enumerables;

public static class Func
{
    public static TAccumulator Fold<T, TAccumulator, TCombinator, TEnumerable, TEnumerator>
    (
        this Enumerable<T, TEnumerator, TEnumerable> enumerable,
        TAccumulator initial,
        TCombinator combinator = default
    )
        where TEnumerator : IEnumerator<T>
        where TEnumerable : IEnumerable<T, TEnumerator>
        where TCombinator : struct, IFunc<TAccumulator, T, TAccumulator>
    {
        TAccumulator result = initial;
        foreach (T i in enumerable)
            result = combinator.Invoke(result, i);
        return result;
    }
}
