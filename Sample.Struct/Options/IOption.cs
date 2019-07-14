namespace Sample.Struct.Options
{
    public interface IOption<T> 
    {
        bool TryGetValue(out NotNull<T> value);
        bool HasValue { get; }
    }
}
