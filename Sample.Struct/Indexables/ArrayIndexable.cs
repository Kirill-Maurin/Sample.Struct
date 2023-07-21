namespace Sample.Struct.Indexables;

public static class ArrayIndexable
{
    public static Indexable<T, int, T[], ArrayIndexator<T>> AsGenericIndexable<T>(this T[] array)
    {
        return array;
    }

    public static Indexable<T, int, ArrayIndexable<T>, DefaultIndexator<T, int, ArrayIndexable<T>>>
        AsStructIndexable<T>(this T[] array)
    {
        return new ArrayIndexable<T>(array);
    }

    public static Indexable<T, int, ArrayIndexable<T>> AsIndexable<T>(this T[] array)
    {
        return new Indexable<T, int, ArrayIndexable<T>>(array);
    }
}
