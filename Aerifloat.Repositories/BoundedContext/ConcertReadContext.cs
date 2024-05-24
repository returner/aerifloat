using Aerifloat.Repositories.BoundedContext.Abstractions;
using Aerifloat.Repositories.Entities;
using Aerifloat.Repositories.Repositories;

namespace Aerifloat.Repositories.BoundedContext;

public class ConcertReadContext : IConcertReadContext
{
    public ConcertReadContext(IReadRepository<Concert> repository)
    {
        
    }
    public Task<int> CreateConcertAsync()
    {
        throw new NotImplementedException();
    }
}
