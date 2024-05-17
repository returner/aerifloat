using Aerifloat.Grains.Core.Repositories;
using Ardalis.Specification;

namespace Opera.ApplicationCore.Abstractions;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IEntityAggregateRoot
{
}
