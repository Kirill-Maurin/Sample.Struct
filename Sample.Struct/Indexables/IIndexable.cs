namespace Sample.Struct.Indexables;

public interface IIndexable<out T, TIndex>
{
    TIndex Count { get; }
    T this[TIndex index] { get; }
}
