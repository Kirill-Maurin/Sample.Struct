namespace Sample.Struct.Summators;

using System.Collections.Generic;
using Enumerables;

public static class Additive
{
    public static T Sum<T, TSummator, TEnumerable, TEnumerator>(
        this Enumerable<T, TEnumerator, TEnumerable> enumerable, Additive<T, TSummator> initial)
        where TEnumerator : IEnumerator<T>
        where TEnumerable : IEnumerable<T, TEnumerator>
        where TSummator : struct, ISummator<T>
    {
        Additive<T, TSummator> result = initial;
        foreach (T i in enumerable)
            result += i;
        return result;
    }

    public static TAccumulator Sum<T, TAccumulator, TSummator, TEnumerable, TEnumerator>(
        this Enumerable<T, TEnumerator, TEnumerable> enumerable, Additive<TAccumulator, T, TSummator> initial)
        where TEnumerator : IEnumerator<T>
        where TEnumerable : IEnumerable<T, TEnumerator>
        where TSummator : struct, ISummator<TAccumulator, T>
    {
        Additive<TAccumulator, T, TSummator> result = initial;
        foreach (T i in enumerable)
            result += i;
        return result;
    }

    public static T Sum<T>(this T[] array, T initial, ISummator<T> summator)
    {
        T result = initial;
        for (int i = 0; i < array.Length; i++)
            result = summator.Add(result, array[i]);
        return result;
    }

    public static T Sum2<T, TSummator>(this T[] array, T initial, TSummator summator)
        where TSummator : ISummator<T>
    {
        T result = initial;
        for (int i = 0; i < array.Length; i++)
            result = summator.Add(result, array[i]);
        return result;
    }

    public static T Sum<T, TSummator>(this T[] array, T initial, TSummator summator = default)
        where TSummator : struct, ISummator<T>
    {
        T result = initial;
        for (int i = 0; i < array.Length; i++)
            result = summator.Add(result, array[i]);
        return result;
    }

    public static T Sum<T, TSummator>(this T[] array, Additive<T, TSummator> initial)
        where TSummator : struct, ISummator<T>
    {
        Additive<T, TSummator> result = initial;
        for (int i = 0; i < array.Length; i++)
            result += array[i];
        return result;
    }

    public static TAccumulator Sum<T, TAccumulator, TSummator>(this T[] array,
        Additive<TAccumulator, T, TSummator> initial)
        where TSummator : struct, ISummator<TAccumulator, T>
    {
        Additive<TAccumulator, T, TSummator> result = initial;
        for (int i = 0; i < array.Length; i++)
            result += array[i];
        return result;
    }
}
