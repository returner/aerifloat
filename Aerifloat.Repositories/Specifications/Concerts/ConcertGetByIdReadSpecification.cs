using Ardalis.Specification;
using Aerifloat.Repositories.Entities;

namespace Aerifloat.Infrastructure.Specifications.Concerts;

public class ConcertGetByIdReadSpecification : Specification<Concert>
{
    public ConcertGetByIdReadSpecification(int id)
    {
        Query
            .Include(d => d.Acts)
            .Include(d => d.Performers)
            .Where(d => d.Id.Equals(id))
            .AsNoTracking();
    }
}