using System;
using System.Text;

namespace Sample.Struct.Summators
{
    public interface ISummator<T>
    {
        T Add(T left, T right);
    }

    public interface ISummator<T, TIncrement>
    {
        T Add(T left, TIncrement right);
    }
}
