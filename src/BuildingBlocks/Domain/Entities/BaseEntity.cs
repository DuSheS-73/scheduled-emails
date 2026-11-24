namespace Domain.Entities;

public abstract class BaseEntity
{
    public string Id { get; private set; } = Guid.NewGuid().ToString();
}
