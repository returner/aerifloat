using Aerifloat.Domain.BoundedContext;
using Aerifloat.Domain.DTOs.Concerts.Commands;
using Aerifloat.Entities.Entities;
using Aerifloat.Entities.Repositories;

namespace Aerifloat.Domain.Domains
{
    public class ConcertCommandContext : IConcertCommandContext
    {
        private readonly IRepository<Concert> _repository;

        public ConcertCommandContext(IRepository<Concert> repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateConcertAsync(CreateConcertDto createConcertDto, CancellationToken cancellationToken = default)
        {
            var concert = new Concert(createConcertDto.Title, createConcertDto.Description, createConcertDto.StartAt, createConcertDto.EndAt);
            await _repository.AddAsync(concert, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return concert.Id;
        }

    }
}
