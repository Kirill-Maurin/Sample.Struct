using Sample.Struct.Summators;

namespace Sample.Struct.Indexables
{
    public static class Indexable
    {
        public static T Sum<T, TSummator, TIndexable>(
            this Indexable<T, int, TIndexable> indexable, Additive<T, TSummator> initial)
            where TIndexable : struct, IIndexable<T, int>
            where TSummator : ISummator<T>
        {
            var result = initial;
            for (var i = 0; i < indexable.Count; i++)
                result += indexable[i];
            return result;
        }
    }

    public struct Indexable<T, TIndex, TIndexable> : IIndexable<T, TIndex>
        where TIndexable : struct, IIndexable<T, TIndex>
    {
        public Indexable(TIndexable indexable) => Unwrap = indexable;

        public TIndexable Unwrap { get; }

        public T this[TIndex index] => Unwrap[index];

        public TIndex Count => Unwrap.Count;
    }

    public struct Indexable<T, TIndex, TIndexable, TIndexator> 
        where TIndexator : struct, IIndexator<T, TIndex, TIndexable>
    {
        public Indexable(TIndexable indexable) => Unwrap = indexable;

        public TIndexable Unwrap { get; }

        public T this[TIndex index] => default(TIndexator).GetItem(Unwrap, index);

        public TIndex Count => default(TIndexator).GetCount(Unwrap);

        public static implicit operator Indexable<T, TIndex, TIndexable, TIndexator>(TIndexable value) => new Indexable<T, TIndex, TIndexable, TIndexator>(value);
        public static implicit operator TIndexable(Indexable<T, TIndex, TIndexable, TIndexator> value) => value.Unwrap;
    }

}
