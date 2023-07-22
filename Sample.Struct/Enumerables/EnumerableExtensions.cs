namespace Sample.Struct.Enumerables;

using System.Collections.Generic;

public static class EnumerableExtensions
{
    public static Enumerable<T, IEnumerator<T>, Enumerable<T>> AsStructEnumerable<T>(this IEnumerable<T> enumerable)
    {
        return new Enumerable<T>(enumerable);
    }

    public static int Sum<TEnumerator, TEnumerable>(this Enumerable<int, TEnumerator, TEnumerable> enumerable)
        where TEnumerator : IEnumerator<int>
        where TEnumerable : IEnumerable<int, TEnumerator>
    {
        int result = 0;
        foreach (int i in enumerable)
            result += i;
        return result;
    }
}
