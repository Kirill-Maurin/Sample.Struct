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

        public static TAccumulator Sum<T, TAccumulator, TSummator, TEnumerable, TEnumerator>(
            this Enumerable<T, TEnumerator, TEnumerable> enumerable, Additive<TAccumulator, T, TSummator> initial)
            where TEnumerator : IEnumerator<T>
            where TEnumerable : IEnumerable<T, TEnumerator>
            where TSummator : struct, ISummator<TAccumulator, T>
        {
            var result = initial;
            foreach (var i in enumerable)
                result += i;
            return result;
        }

        /*
        public static T Sum<T>(this T[] array, T initial)
        {
            var result = initial;
            for (var i = 0; i < array.Length; i++)
                result += array[i];
            return result;
        }
        */

        public static T Sum<T>(this T[] array, T initial, ISummator<T> summator)
        {
            var result = initial;
            for (var i = 0; i < array.Length; i++)
                result = summator.Add(result, array[i]);
            return result;
        }

        public static T Sum2<T, TSummator>(this T[] array, T initial, TSummator summator)
            where TSummator : ISummator<T>
        {
            var result = initial;
            for (var i = 0; i < array.Length; i++)
                result = summator.Add(result, array[i]);
            return result;
        }

        public static T Sum<T, TSummator>(this T[] array, T initial, TSummator summator = default)
            where TSummator : struct, ISummator<T>
        {
            var result = initial;
            for (var i = 0; i < array.Length; i++)
                result = summator.Add(result, array[i]);
            return result;
        }

        public static T Sum<T, TSummator>(this T[] array, Additive<T, TSummator> initial)
            where TSummator : struct, ISummator<T>
        {
            var result = initial;
            for (var i = 0; i < array.Length; i++)
                result += array[i];
            return result;
        }
    }

    public struct Additive<T, TSummator> where TSummator : struct, ISummator<T>
    {
        Additive(T value) => Value = value;

        public T Value { get; }

        public static Additive<T, TSummator> operator +(Additive<T, TSummator> left, Additive<T, TSummator> right)
        {
            var summator = default(TSummator);
            return summator.Add(left, right);
        }

        public static implicit operator Additive<T, TSummator>(T value) => new Additive<T, TSummator>(value);
        public static implicit operator T(Additive<T, TSummator> value) => value.Value;
    }

    public struct Additive<TAccumulator, TIncrement, TSummator> 
        where TSummator : struct, ISummator<TAccumulator, TIncrement>
    {
        public TAccumulator Value { get; }

        public static Additive<TAccumulator, TIncrement, TSummator> operator +
            (Additive<TAccumulator, TIncrement, TSummator> left, TIncrement right)
            => default(TSummator).Add(left, right);

        public static implicit operator Additive<TAccumulator, TIncrement, TSummator>(TAccumulator value) => new Additive<TAccumulator, TIncrement, TSummator>(value);
        public static implicit operator TAccumulator(Additive<TAccumulator, TIncrement, TSummator> value) => value.Value;

        Additive(TAccumulator value) => Value = value;
    }
}
