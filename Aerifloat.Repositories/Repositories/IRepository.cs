using Ardalis.Specification;

namespace Aerifloat.Repositories.Repositories;

public interface IRepository<T> : IRepositoryBase<T> where T : class, IEntityAggregateRoot
{
}
