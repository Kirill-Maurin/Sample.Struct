namespace Sample.Struct.Options;

public interface IOption<T>
{
    bool HasValue { get; }
    bool TryGetValue(out NotNull<T> value);
}