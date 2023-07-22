namespace Sample.Struct.Indexables;

using System.Runtime.CompilerServices;
using Summators;

public static class Indexable
{
    public static T Sum<T, TSummator, TIndexable>(
        this Indexable<T, int, TIndexable> indexable, Additive<T, TSummator> initial)
        where TIndexable : struct, IIndexable<T, int>
        where TSummator : struct, ISummator<T>
    {
        Additive<T, TSummator> result = initial;
        for (int i = 0; i < indexable.Count; i++)
            result += indexable[i];
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TAccumulator Sum<T, TAccumulator, TSummator, TIndexable>(
        this Indexable<T, int, TIndexable> indexable, Additive<TAccumulator, T, TSummator> initial)
        where TIndexable : struct, IIndexable<T, int>
        where TSummator : struct, ISummator<TAccumulator, T>
    {
        Additive<TAccumulator, T, TSummator> result = initial;
        for (int i = 0; i < indexable.Count; i++)
            result += indexable[i];
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TAccumulator Sum<T, TAccumulator, TSummator, TIndexable, TIndexator>(
        this Indexable<T, int, TIndexable, TIndexator> indexable, Additive<TAccumulator, T, TSummator> initial)
        where TIndexator : struct, IIndexator<T, int, TIndexable>
        where TSummator : struct, ISummator<TAccumulator, T>
    {
        Additive<TAccumulator, T, TSummator> result = initial;
        for (int i = 0; i < indexable.Count; i++)
            result += indexable[i];
        return result;
    }
}

public readonly struct Indexable<T, TIndex, TIndexable> : IIndexable<T, TIndex>
    where TIndexable : struct, IIndexable<T, TIndex>
{
    public Indexable(TIndexable indexable)
    {
        this.Value = indexable;
    }

    public TIndexable Value { get; }

    public T this[TIndex index] => this.Value[index];

    public TIndex Count => this.Value.Count;
}

public struct Indexable<T, TIndex, TIndexable, TIndexator>
    where TIndexator : struct, IIndexator<T, TIndex, TIndexable>
{
    public Indexable(TIndexable indexable)
    {
        this.Value = indexable;
    }

    public TIndexable Value { get; }

    public T this[TIndex index]
    {
        get
        {
            var indexator = default(TIndexator);
            return indexator.GetItem(this.Value, index);
        }
    }

    public TIndex Count
    {
        get
        {
            var indexator = default(TIndexator);
            return indexator.GetCount(this.Value);
        }
    }

    public static implicit operator Indexable<T, TIndex, TIndexable, TIndexator>(TIndexable value)
    {
        return new Indexable<T, TIndex, TIndexable, TIndexator>(value);
    }

    public static implicit operator TIndexable(Indexable<T, TIndex, TIndexable, TIndexator> value)
    {
        return value.Value;
    }
}
