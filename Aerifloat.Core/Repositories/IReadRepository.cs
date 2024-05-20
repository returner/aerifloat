using Ardalis.Specification;

namespace Aerifloat.Core.Repositories;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IEntityAggregateRoot
{
}
