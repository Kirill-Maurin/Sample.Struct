using System;
using System.Collections.Generic;
using Sample.Struct.Indexables;

namespace Sample.Struct.Equatables
{
    public static class Equatable
    {
        public static Equatable<int, IntComparer> AsEquatable(this int value) 
            => new Equatable<int, IntComparer>(value);

        public static Equatable<T, DefaultComparer<T>> AsDefaultEquatable<T>(this T value)
            => new Equatable<T, DefaultComparer<T>>(value);

        public static bool SequenceEqual<T, TIndexable, TComparer>(this Indexable<T, int, TIndexable> left, Indexable<T, int, TIndexable> right, TComparer _)
            where TIndexable: IIndexable<T, int>
            where TComparer: struct, IEqualityComparer<T>
        {
            if (left.Count != right.Count)
                return false;

            for (var i = 0; i < left.Count; i++)
                if (new Equatable<T, TComparer>(left[i]) != right[i])
                    return false;

            return true;
        }
    }

    public struct Equatable<T, TComparer> : IEquatable<Equatable<T, TComparer>> where TComparer : struct, IEqualityComparer<T>
    {
        public Equatable(T value) => Value = value;
        public T Value { get; }

        public override bool Equals(object obj)
            => obj is Equatable<T, TComparer> equatable && equatable == this;

        public bool Equals(Equatable<T, TComparer> other) => this == other;

        public override int GetHashCode() => default(TComparer).GetHashCode(Value);

        public static bool operator ==(Equatable<T, TComparer> left, Equatable<T, TComparer> right) => default(TComparer).Equals(left, right);
        public static bool operator !=(Equatable<T, TComparer> left, Equatable<T, TComparer> right) => !default(TComparer).Equals(left, right);

        public static implicit operator T(Equatable<T, TComparer> value) => value.Value;
        public static implicit operator Equatable<T, TComparer>(T value) => new Equatable<T, TComparer>(value);
    }

}
