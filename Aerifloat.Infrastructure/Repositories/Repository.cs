using Aerifloat.Core.Repositories;
using Aerifloat.Infrastructure.Context;
using Ardalis.Specification.EntityFrameworkCore;

namespace Aerifloat.Infrastructure.Repositories
{
    public class Repository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IEntityAggregateRoot
    {
        public Repository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
