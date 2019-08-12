namespace Sample.Struct.Indexables
{
    public static class ArrayIndexable
    {
        public static Indexable<T, int, T[], ArrayIndexator<T>> AsGenericIndexable<T>(this T[] array)
            => array;

        public static Indexable<T, int, ArrayIndexable<T>, DefaultIndexator<T, int, ArrayIndexable<T>>> AsStructIndexable<T>(this T[] array)
            => new ArrayIndexable<T>(array);

        public static Indexable<T, int, ArrayIndexable<T>> AsIndexable<T>(this T[] array)
            => new Indexable<T, int, ArrayIndexable<T>>(array);
    }

    public struct ArrayIndexable<T> : IIndexable<T, int>
    {
        internal ArrayIndexable(T[] value) => Unwrap = value;

        public T[] Unwrap { get; }

        public T this[int index] => Unwrap[index];

        public int Count => Unwrap.Length;

        public static implicit operator ArrayIndexable<T>(T[] array) => new ArrayIndexable<T>(array);
        public static implicit operator T[](ArrayIndexable<T> value) => value.Unwrap;
    }
}
