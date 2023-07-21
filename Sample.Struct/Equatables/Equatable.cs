namespace Sample.Struct.Equatables;

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Indexables;

public static class Equatable
{
    public static Equatable<int, IntComparer> AsEquatable(this int value)
    {
        return new Equatable<int, IntComparer>(value);
    }

    public static Equatable<T, TComparer> AsEquatable<T, TComparer>(this T value, TComparer _)
        where TComparer : struct, IEqualityComparer<T>
    {
        return value;
    }

    public static Equatable<T, DefaultComparer<T>> AsDefaultEquatable<T>(this T value)
    {
        return new Equatable<T, DefaultComparer<T>>(value);
    }

    public static bool SequenceEqual<T, TLeftIndexable, TRightIndexable, TComparer>
    (
        this Indexable<T, int, TLeftIndexable> left,
        Indexable<T, int, TRightIndexable> right,
        TComparer comparer = default
    )
        where TLeftIndexable : struct, IIndexable<T, int>
        where TRightIndexable : struct, IIndexable<T, int>
        where TComparer : struct, IEqualityComparer<T>
    {
        if (left.Count != right.Count)
            return false;

        for (int i = 0; i < left.Count; i++)
        {
            Equatable<T, TComparer> l = left[i];
            if (l != right[i])
                return false;
        }

        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool SequenceEqual<T, TIndexable, TIndexator, TComparer>
    (
        this Indexable<T, int, TIndexable, TIndexator> left,
        Indexable<T, int, TIndexable, TIndexator> right,
        TComparer _
    )
        where TComparer : struct, IEqualityComparer<T>
        where TIndexator : struct, IIndexator<T, int, TIndexable>
    {
        if (left.Count != right.Count)
            return false;

        for (int i = 0; i < left.Count; i++)
            if (left[i].AsEquatable(_) != right[i])
                return false;

        return true;
    }
}

public struct Equatable<T, TComparer> : IEquatable<Equatable<T, TComparer>>
    where TComparer : struct, IEqualityComparer<T>
{
    public Equatable(T value)
    {
        this.Value = value;
    }

    public T Value { get; }

    public override bool Equals(object obj)
    {
        return obj is Equatable<T, TComparer> equatable && equatable == this;
    }

    public bool Equals(Equatable<T, TComparer> other)
    {
        return this == other;
    }

    public override int GetHashCode()
    {
        return default(TComparer).GetHashCode(this.Value);
    }

    public static bool operator ==(Equatable<T, TComparer> left, Equatable<T, TComparer> right)
    {
        var comparer = default(TComparer);
        return comparer.Equals(left, right);
    }

    public static bool operator !=(Equatable<T, TComparer> left, Equatable<T, TComparer> right)
    {
        var comparer = default(TComparer);
        return !comparer.Equals(left, right);
    }

    public static implicit operator T(Equatable<T, TComparer> value)
    {
        return value.Value;
    }

    public static implicit operator Equatable<T, TComparer>(T value)
    {
        return new Equatable<T, TComparer>(value);
    }
}
