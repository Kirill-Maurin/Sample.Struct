namespace Sample.Struct.Indexables;

public interface IIndexable<out T, TIndex>
{
    TIndex Count { get; }
    T this[TIndex index] { get; }
}

public interface IIndexator<out T, TIndex, in TIndexable>
{
    TIndex GetCount(TIndexable indexable);
    T GetItem(TIndexable indexable, TIndex index);
}