namespace Sample.Struct.Summators;

public static class AdditiveV2
{
    public static T Sum<T, TSummator>(this T[] array, AdditiveV2<T, TSummator> initial)
        where TSummator : struct, ISummator<T>
    {
        AdditiveV2<T, TSummator> result = initial;
        for (int i = 0; i < array.Length; i++)
            result += array[i];
        return result;
    }
}
