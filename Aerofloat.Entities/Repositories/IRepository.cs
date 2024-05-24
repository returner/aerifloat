using Aerofloat.Entities.Entities.Base;
using Ardalis.Specification;

namespace Aerofloat.Entities.Repositories;

public interface IRepository<T> : IRepositoryBase<T> where T : class, IEntityAggregateRoot
{
}
