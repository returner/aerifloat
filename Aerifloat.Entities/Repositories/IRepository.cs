using Aerifloat.Entities.Entities.Base;
using Ardalis.Specification;

namespace Aerifloat.Entities.Repositories;

public interface IRepository<T> : IRepositoryBase<T> where T : class, IEntityAggregateRoot
{
}
