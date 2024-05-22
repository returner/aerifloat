using Aerifloat.Repositories.Context;
using Ardalis.Specification.EntityFrameworkCore;

namespace Aerifloat.Repositories.Repositories;

public class Repository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IEntityAggregateRoot
{
    public Repository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
