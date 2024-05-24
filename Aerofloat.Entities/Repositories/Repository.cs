using Aerofloat.Entities.Context;
using Aerofloat.Entities.Entities.Base;
using Ardalis.Specification.EntityFrameworkCore;

namespace Aerofloat.Entities.Repositories;

public class Repository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IEntityAggregateRoot
{
    public Repository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
