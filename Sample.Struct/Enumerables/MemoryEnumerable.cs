namespace Sample.Struct.Enumerables;

using System;
using System.Collections;
using System.Collections.Generic;

public static class MemoryEnumerable
{
    public static Enumerable<T, MemoryEnumerator<T>, MemoryEnumerable<T>> AsStructEnumerable<T>(this Memory<T> memory)
    {
        return new MemoryEnumerable<T>(memory);
    }
}

public readonly struct MemoryEnumerable<T> : IEnumerable<T, MemoryEnumerator<T>>
{
    internal MemoryEnumerable(Memory<T> value)
    {
        Value = value;
    }

    public Memory<T> Value { get; }

    public MemoryEnumerator<T> GetEnumerator()
    {
        return new MemoryEnumerator<T>(Value);
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        return GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public static class SpanEnumerable
{
    public static SpanEnumerable<T> AsSpanEnumerable<T>(this Span<T> memory)
    {
        return new SpanEnumerable<T>(memory);
    }
}
