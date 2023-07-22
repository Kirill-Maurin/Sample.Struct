namespace Sample.Struct.Indexables;

using System.Runtime.CompilerServices;

public struct ArrayIndexator<T> : IIndexator<T, int, T[]>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T GetItem(T[] array, int index)
    {
        return array[index];
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int GetCount(T[] array)
    {
        return array.Length;
    }
}
