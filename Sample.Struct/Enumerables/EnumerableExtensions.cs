namespace Sample.Struct.Enumerables;

public static class EnumerableExtensions
{
    public static Enumerable<T, IEnumerator<T>, Enumerable<T>> AsStructEnumerable<T>(this IEnumerable<T> enumerable)
        => new Enumerable<T>(enumerable);

    public static int Sum<TEnumerator, TEnumerable>(this Enumerable<int, TEnumerator, TEnumerable> enumerable)
        where TEnumerator : IEnumerator<int>
        where TEnumerable : IEnumerable<int, TEnumerator>
    {
        var result = 0;
        foreach (var i in enumerable)
            result += i;
        return result;
    }
}