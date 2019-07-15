using System.Collections;
using System.Collections.Generic;

namespace Sample.Struct.Enumerables
{
    public struct ArrayEnumerator<T> : IEnumerator<T>
    {
        internal ArrayEnumerator(T[] array) => (_i, _array) = (-1, array);

        readonly T[] _array;

        int _i;

        public T Current => _array[_i];

        object IEnumerator.Current => Current;

        public void Dispose() {}

        public bool MoveNext() => ++_i < _array.Length;

        public void Reset() => throw new System.NotImplementedException();
    }
}