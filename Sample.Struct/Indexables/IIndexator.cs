namespace Sample.Struct.Indexables;

public interface IIndexator<out T, TIndex, in TIndexable>
{
    TIndex GetCount(TIndexable indexable);
    T GetItem(TIndexable indexable, TIndex index);
}
