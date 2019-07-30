using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Sample.Struct.Enumerables
{
    public struct ArrayEnumerator<T> : IEnumerator<T>
    {
        internal ArrayEnumerator(T[] array) => (_i, _array, Current) = (-1, array, default);

        readonly T[] _array;

        int _i;

        public T Current { get; private set; }

        object IEnumerator.Current => Current;

        public void Dispose() {}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MoveNext()
        {            
            if (++_i >= _array.Length)
                return false;
            Current = _array[_i];
            return true;
        }

        public void Reset() => throw new System.NotImplementedException();
    }
}