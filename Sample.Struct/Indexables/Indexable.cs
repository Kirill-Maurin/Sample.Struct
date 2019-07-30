using Sample.Struct.Summators;

namespace Sample.Struct.Indexables
{
    public static class Indexable
    {
        public static Additive<T, TSummator> Sum<T, TSummator, TIndexator>(
            this Indexable<T, int, TIndexator> indexable, Additive<T, TSummator> initial)
            where TIndexator : IIndexable<T, int>
            where TSummator : ISummator<T>
        {
            var result = initial;
            for (var i = 0; i < indexable.Count; i++)
                result += indexable[i];
            return result;
        }
    }

    public struct Indexable<T, TIndex, TIndexable> : IIndexable<T, TIndex>
        where TIndexable : IIndexable<T, TIndex>
    {
        public Indexable(TIndexable indexable) => Unwrap = indexable;

        public TIndexable Unwrap { get; }

        public T this[TIndex index] => Unwrap[index];

        public TIndex Count => Unwrap.Count;
    }

}
