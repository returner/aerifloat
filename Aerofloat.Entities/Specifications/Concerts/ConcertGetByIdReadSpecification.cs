using Ardalis.Specification;
using Aerofloat.Entities.Entities;

namespace Aerofloat.Entities.Specifications.Concerts;

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