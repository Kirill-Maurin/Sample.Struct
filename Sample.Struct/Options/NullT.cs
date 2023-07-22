namespace Sample.Struct.Options;

using System;

public readonly struct NullT<T> : IEquatable<NullT<T>>, IOption<T>
{
    internal static Option<T, NullT<T>> Instance = new();

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString()
    {
        return $"Null<{nameof(T)}>";
    }

    public override bool Equals(object obj)
    {
        return obj is NullT<T> notNull;
    }

    public bool Equals(NullT<T> other)
    {
        return true;
    }

    public static bool operator ==(NullT<T> left, NullT<T> right)
    {
        return true;
    }

    public static bool operator !=(NullT<T> left, NullT<T> right)
    {
        return false;
    }

    public bool TryGetValue(out NotNull<T> value)
    {
        value = default;
        return false;
    }

    public bool HasValue => false;
}
