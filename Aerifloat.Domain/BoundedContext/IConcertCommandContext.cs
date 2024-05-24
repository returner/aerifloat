using Aerifloat.Domain.BoundedContext.Abstractions;
using Aerifloat.Domain.DTOs.Concerts.Commands;

namespace Aerifloat.Domain.BoundedContext;

public interface IConcertCommandContext : IBoundedContext
{
    public Task<int> CreateConcertAsync(CreateConcertDto createConcertDto, CancellationToken cancellationToken=default);
}