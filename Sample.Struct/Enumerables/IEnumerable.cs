namespace Sample.Struct.Enumerables;

public interface IEnumerable<out T, out TEnumerator> : IEnumerable<T> where TEnumerator : IEnumerator<T>
{
    new TEnumerator GetEnumerator();
}