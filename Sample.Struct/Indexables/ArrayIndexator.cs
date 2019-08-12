using System.Runtime.CompilerServices;

namespace Sample.Struct.Indexables
{
    public struct ArrayIndexator<T> : IIndexator<T, int, T[]>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T GetItem(T[] array, int index) => array[index];

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetCount(T[] array) => array.Length;
    }
}
