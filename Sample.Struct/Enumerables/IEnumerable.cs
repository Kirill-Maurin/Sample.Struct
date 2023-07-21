namespace Sample.Struct.Enumerables;

using System.Collections.Generic;

public interface IEnumerable<out T, out TEnumerator> : IEnumerable<T> where TEnumerator : IEnumerator<T>
{
    new TEnumerator GetEnumerator();
}
