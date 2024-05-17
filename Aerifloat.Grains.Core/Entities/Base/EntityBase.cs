using Aerifloat.Grains.Core.Repositories;

namespace Aerifloat.Grains.Core.Entities.Base
{
    public class EntityBase<T> : IEntityAggregateRoot where T : struct
    {
        public T Id { get; private set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
