namespace Sample.Struct.Summators
{
    public static class Additive2
    {
        public static T Sum<T, TSummator>(this T[] array, Additive2<T, TSummator> initial)
            where TSummator : struct, ISummator<T>
        {
            var result = initial;
            for (var i = 0; i < array.Length; i++)
                result += array[i];
            return result;
        }
    }

    public struct Additive2<T, TSummator> where TSummator : struct, ISummator<T>
    {
        Additive2(T value) => Value = value;

        public T Value { get; }

        public static Additive2<T, TSummator> operator +(Additive2<T, TSummator> left, Additive2<T, TSummator> right)
            => default(TSummator).Add(left, right);

        public static implicit operator Additive2<T, TSummator>(T value) => new Additive2<T, TSummator>(value);
        public static implicit operator T(Additive2<T, TSummator> value) => value.Value;
    }
}
