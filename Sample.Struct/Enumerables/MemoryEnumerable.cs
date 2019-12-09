using System;
using System.Collections;
using System.Collections.Generic;

namespace Sample.Struct.Enumerables
{
    public static class MemoryEnumerable
    {
        public static Enumerable<T, MemoryEnumerator<T>, MemoryEnumerable<T>> AsStructEnumerable<T>(this Memory<T> memory)
            => new MemoryEnumerable<T>(memory);
    }

    public readonly struct MemoryEnumerable<T> : IEnumerable<T, MemoryEnumerator<T>>
    {
        internal MemoryEnumerable(Memory<T> value) => Value = value;

        public Memory<T> Value { get; }

        public MemoryEnumerator<T> GetEnumerator() => new MemoryEnumerator<T>(Value);

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public static class SpanEnumerable
    {
        public static SpanEnumerable<T> AsSpanEnumerable<T>(this Span<T> memory)
            => new SpanEnumerable<T>(memory);
    }
}