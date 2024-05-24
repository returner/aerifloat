namespace Aerifloat.Repositories.BoundedContext.Abstractions;

public interface IConcertReadContext : IBoundedContext
{
    Task<int> CreateConcertAsync();
}
