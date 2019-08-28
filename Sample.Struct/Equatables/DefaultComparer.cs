using System.Collections.Generic;

namespace Sample.Struct.Equatables
{
    public struct DefaultComparer<T> : IEqualityComparer<T>
    {
        public bool Equals(T left, T right) => EqualityComparer<T>.Default.Equals(left, right);

        public int GetHashCode(T obj) => EqualityComparer<T>.Default.GetHashCode(obj);
    }
}
