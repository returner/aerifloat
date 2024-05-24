using Aerifloat.Domain.BoundedContext;
using Aerifloat.Domain.DTOs.Concerts.Commands;
using Aerifloat.Grains.Abstractions;
using Aerifloat.Grains.Dtos.Grains.Concerts;

namespace Aerifloat.Grains
{
    public class ConcertGrain : Grain, IConcertGrain
    {
        private readonly IConcertCommandContext _context;

        public ConcertGrain(IConcertCommandContext context)
        {
            _context = context;
        }

        public async Task<int> AddActsToConcert(int concertId, IEnumerable<GrainCreateActDto> actDtos)
        {
            await Task.CompletedTask;
            return default;
        }

        public async Task<int> AddPerformersToConcert(int concertId, IEnumerable<GrainCreatePerformerDto> performerDtos)
        {
            await Task.CompletedTask;
            return default;
        }

        public async Task<int> AddSessionToAct(long actId, IEnumerable<GrainCreateSesionDto> sesionDtos)
        {
            await Task.CompletedTask;
            return default;
        }

        public async Task<int> CreateConcertAsync(GrainCreateConcertDto concertDto)
        {
            var id = await _context.CreateConcertAsync(new CreateConcertDto
            {
                Title = concertDto.Title,
                Description = concertDto.Description,
                StartAt = concertDto.StartAt,
                EndAt = concertDto.EndAt,
            });
            return id;
        }
    }
}
