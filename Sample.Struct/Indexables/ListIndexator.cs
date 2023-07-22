namespace Sample.Struct.Indexables;

using System.Collections.Generic;

public struct ListIndexator<T> : IIndexator<T, int, List<T>>
{
    public T GetItem(List<T> list, int index)
    {
        return list[index];
    }

    public int GetCount(List<T> list)
    {
        return list.Count;
    }
}
