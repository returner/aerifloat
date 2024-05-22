using Aerifloat.Repositories.Repositories;

namespace Aerifloat.Repositories.Entities.Base;

public class EntityBase<T> : IEntityAggregateRoot where T : struct
{
    public T Id { get; private set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
