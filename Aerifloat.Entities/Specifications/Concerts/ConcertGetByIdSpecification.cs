using Ardalis.Specification;
using Aerifloat.Entities.Entities;

namespace Aerifloat.Entities.Specifications.Concerts;

public class ConcertGetByIdSpecification : Specification<Concert>
{
    public ConcertGetByIdSpecification(int id)
    {
        Query
            .Include(d => d.Acts)
            .Include(d => d.Performers)
            .Where(d => d.Id.Equals(id));
    }
}
