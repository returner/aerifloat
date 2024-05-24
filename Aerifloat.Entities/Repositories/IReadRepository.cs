using Aerifloat.Entities.Entities.Base;
using Ardalis.Specification;

namespace Aerifloat.Entities.Repositories;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IEntityAggregateRoot
{
}
