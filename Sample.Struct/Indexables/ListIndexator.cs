namespace Sample.Struct.Indexables;

public struct ListIndexator<T> : IIndexator<T, int, List<T>>
{
    public T GetItem(List<T> list, int index) => list[index];

    public int GetCount(List<T> list) => list.Count;
}