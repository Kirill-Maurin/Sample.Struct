namespace Sample.Struct;

public static class Key
{
    public static Key<T, TKey> AsKey<T, TKey>(this TKey id, T _)
    {
        return new Key<T, TKey>(id);
    }
}
