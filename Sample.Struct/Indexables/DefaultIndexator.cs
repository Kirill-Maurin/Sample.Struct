namespace Sample.Struct.Indexables;

public struct DefaultIndexator<T, TIndex, TIndexable> : IIndexator<T, TIndex, TIndexable>
    where TIndexable : struct, IIndexable<T, TIndex>
{
    public TIndex GetCount(TIndexable indexable)
    {
        return indexable.Count;
    }

    public T GetItem(TIndexable indexable, TIndex index)
    {
        return indexable[index];
    }
}
