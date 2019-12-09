using System.Collections.Generic;
using Sample.Struct.Enumerables;
using Sample.Struct.Functions;
using Sample.Struct.Summators;

namespace Sample.Struct
{
    public interface IFunc<in TIn, out T>
    {
        T Invoke(TIn arg);
    }

    public interface IFunc<in TLeft, TRight, out T>
    {
        T Invoke(TLeft left, TRight right);
    }

    public static class IFunc
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
            var result = initial;
            foreach (var i in enumerable)
                result = combinator.Invoke(result, i);
            return result;
        }        
    }
}
