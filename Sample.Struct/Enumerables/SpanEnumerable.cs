﻿namespace Sample.Struct.Enumerables;

using System;

public readonly ref struct SpanEnumerable<T>
{
    internal SpanEnumerable(Span<T> value)
    {
        Value = value;
    }

    public Span<T> Value { get; }

    public SpanEnumerator<T> GetEnumerator()
    {
        return new SpanEnumerator<T>(Value);
    }
}
