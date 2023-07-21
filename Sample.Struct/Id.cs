namespace Sample.Struct;

public static class Id
{
    public static Id<T, TKey> AsId<T, TKey>(this TKey id, T _) where T : IEntity<TKey>
    {
        return new Id<T, TKey>(id);
    }

    public static Id<T, TKey> GetId<T, TKey>(this T entity) where T : IEntity<TKey>
    {
        return new Id<T, TKey>(entity.Id);
    }
}
