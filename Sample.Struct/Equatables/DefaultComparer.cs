namespace Sample.Struct.Equatables;

using System.Collections.Generic;

public struct DefaultComparer<T> : IEqualityComparer<T>
{
    public bool Equals(T left, T right)
    {
        return EqualityComparer<T>.Default.Equals(left, right);
    }

    public int GetHashCode(T obj)
    {
        return EqualityComparer<T>.Default.GetHashCode(obj);
    }
}
