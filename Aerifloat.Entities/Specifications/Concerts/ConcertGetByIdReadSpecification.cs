using Ardalis.Specification;
using Aerifloat.Entities.Entities;

namespace Aerifloat.Entities.Specifications.Concerts;

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