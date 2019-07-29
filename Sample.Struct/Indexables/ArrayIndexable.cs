namespace Sample.Struct.Indexables
{
    public static class ArrayIndexable
    {
        public static Indexable<T, int, ArrayIndexable<T>> AsIndexable<T>(this T[] array)
            => new Indexable<T, int, ArrayIndexable<T>>(new ArrayIndexable<T>(array));
    }

    public struct ArrayIndexable<T> : IIndexable<T, int>
    {
        internal ArrayIndexable(T[] value) => Unwrap = value;

        public T[] Unwrap { get; }

        public T this[int index] => Unwrap[index];

        public int Count => Unwrap.Length;
    }

}
