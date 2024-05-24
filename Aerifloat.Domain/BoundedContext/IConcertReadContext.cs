using Aerifloat.Domain.BoundedContext.Abstractions;

namespace Aerifloat.Domain.BoundedContext;

public interface IConcertReadContext : IBoundedContext
{
    Task<int> CreateConcertAsync();
}
