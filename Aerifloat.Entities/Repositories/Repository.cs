using Aerifloat.Entities.Context;
using Aerifloat.Entities.Entities.Base;
using Ardalis.Specification.EntityFrameworkCore;

namespace Aerifloat.Entities.Repositories;

public class Repository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IEntityAggregateRoot
{
    public Repository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
