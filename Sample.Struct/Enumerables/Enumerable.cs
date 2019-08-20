using System.Collections;
using System.Collections.Generic;

namespace Sample.Struct.Enumerables
{
    public readonly struct Enumerable<T, TEnumerator, TEnumerable> : IEnumerable<T, TEnumerator>
        where TEnumerator : IEnumerator<T> 
        where TEnumerable : IEnumerable<T, TEnumerator>
    {        
        public Enumerable(TEnumerable value) => Value = value;

        public TEnumerable Value { get; }

        public TEnumerator GetEnumerator() => Value.GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public readonly struct Enumerable<T> : IEnumerable<T, IEnumerator<T>>
    {
        internal Enumerable(IEnumerable<T> unwrap) => Value = unwrap;

        public IEnumerable<T> Value { get; }

        public IEnumerator<T> GetEnumerator() => Value.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}