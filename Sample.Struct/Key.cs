namespace Sample.Struct;

public static class Key
{
    public static Key<T, TKey> AsKey<T, TKey>(this TKey id, T _) => new(id);
}

public readonly struct Key<T, TKey> : IEquatable<Key<T, TKey>>
{
    internal Key(TKey id) => Value = id;

    public TKey Value { get; }

    public override bool Equals(object obj) => obj is Key<T, TKey> id && Equals(id);

    public bool Equals(Key<T, TKey> other) => EqualityComparer<TKey>.Default.Equals(Value, other.Value);

    public override int GetHashCode() => Value.GetHashCode();

    public static bool operator ==(Key<T, TKey> left, Key<T, TKey> right) => left.Equals(right);

    public static bool operator !=(Key<T, TKey> left, Key<T, TKey> right) => !(left == right);
}