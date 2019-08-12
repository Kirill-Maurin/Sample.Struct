using System.Collections.Generic;

namespace Sample.Struct.Equatables
{
    public struct DefaultComparer<T> : IEqualityComparer<T>
    {
        public bool Equals(T left, T right) => _comparer.Equals(left, right);

        public int GetHashCode(T obj) => _comparer.GetHashCode(obj);

        static EqualityComparer<T> _comparer = EqualityComparer<T>.Default;
    }

}
