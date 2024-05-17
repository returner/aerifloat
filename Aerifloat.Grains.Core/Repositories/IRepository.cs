using Ardalis.Specification;

namespace Aerifloat.Grains.Core.Repositories;

public interface IRepository<T> : IRepositoryBase<T> where T : class, IEntityAggregateRoot
{
}
