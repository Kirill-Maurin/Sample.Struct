namespace Sample.Struct;

public interface IEntity<out T>
{
    T Id { get; }
}