namespace Sample.Struct.Summators;

public interface ISummator<T, TIncrement>
{
    T Add(T left, TIncrement right);
}
