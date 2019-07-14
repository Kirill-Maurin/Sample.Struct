using System.Collections;
using System.Collections.Generic;

namespace Sample.Struct.Enumerables
{
    public readonly struct Enumerable<T, TEnumerator, TEnumerable> : IEnumerable<T, TEnumerator>
        where TEnumerator : IEnumerator<T> 
        where TEnumerable : IEnumerable<T, TEnumerator>
    {        
        public Enumerable(TEnumerable unwrap) => Unwrap = unwrap;

        public TEnumerable Unwrap { get; }

        public TEnumerator GetEnumerator() => Unwrap.GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public readonly struct Enumerable<T> : IEnumerable<T, IEnumerator<T>>
    {
        internal Enumerable(IEnumerable<T> unwrap) => Unwrap = unwrap;

        public IEnumerable<T> Unwrap { get; }

        public IEnumerator<T> GetEnumerator() => Unwrap.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}