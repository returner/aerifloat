namespace Aerifloat.Repositories.BoundedContext.Abstractions;

public interface IConcertCommandContext : IBoundedContext
{
    Task<int> CreateConcertAsync()
}