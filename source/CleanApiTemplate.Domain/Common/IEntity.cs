namespace CleanApiTemplate.Domain.Common
{
    public interface IEntity<out TKey>
    {
        TKey Id { get; }
    }
}
