namespace Sample.Struct.Indexables;

using System.Collections.Generic;

public static class ListIndexable
{
    public static Indexable<T, int, ListIndexable<T>> AsIndexable<T>(this List<T> list)
    {
        return new Indexable<T, int, ListIndexable<T>>(new ListIndexable<T>(list));
    }
}
