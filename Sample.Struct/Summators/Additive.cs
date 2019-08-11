using System.Collections.Generic;
using Sample.Struct.Enumerables;

namespace Sample.Struct.Summators
{
    public static class Additive
    {
        public static T Sum<T, TSummator, TEnumerable, TEnumerator>(
            this Enumerable<T, TEnumerator, TEnumerable> enumerable, Additive<T, TSummator> initial)
            where TEnumerator : IEnumerator<T>
            where TEnumerable : IEnumerable<T, TEnumerator>
            where TSummator : struct, ISummator<T>
        {
            var result = initial;
            foreach (var i in enumerable)
                result += i;
            return result;
        }
    }

    public struct Additive<T, TSummator> where TSummator : ISummator<T>
    {
        public static Additive<T, TSummator> Wrap(T value) => new Additive<T, TSummator>(value);

        internal Additive(T value) => Unwrap = value;

        public T Unwrap { get; }

        public static Additive<T, TSummator> operator +(Additive<T, TSummator> left, Additive<T, TSummator> right)
            => default(TSummator).Add(left, right);

        public static implicit operator Additive<T, TSummator>(T value) => Wrap(value);
        public static implicit operator T(Additive<T, TSummator> value) => value.Unwrap;
    }
}
