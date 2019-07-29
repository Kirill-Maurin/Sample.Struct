using Sample.Struct.Summators;

namespace Sample.Struct.Indexables
{
    public static class Indexable
    {
        public static Additive<T, TTypeclass> Sum<T, TTypeclass, TIndexator>(
            this Indexable<T, int, TIndexator> indexable, Additive<T, TTypeclass> initial)
            where TIndexator : IIndexable<T, int>
            where TTypeclass : ISummator<T>
        {
            var result = initial;
            for(var i = 0; i < indexable.Count; i++)
                result += Additive<T, TTypeclass>.Wrap(indexable[i]);
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
