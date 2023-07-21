namespace Sample.Struct.Summators;

public interface ISummator<T>
{
    T Add(T left, T right);
}
