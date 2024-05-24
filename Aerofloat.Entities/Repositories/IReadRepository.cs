using Aerofloat.Entities.Entities.Base;
using Ardalis.Specification;

namespace Aerofloat.Entities.Repositories;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IEntityAggregateRoot
{
}
