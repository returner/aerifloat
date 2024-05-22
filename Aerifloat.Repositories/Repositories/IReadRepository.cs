using Ardalis.Specification;

namespace Aerifloat.Repositories.Repositories;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IEntityAggregateRoot
{
}
