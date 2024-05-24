using Aerifloat.Domain.BoundedContext;
using Aerifloat.Entities.Entities;
using Aerifloat.Entities.Repositories;

namespace Aerifloat.Domain.Domains;

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
