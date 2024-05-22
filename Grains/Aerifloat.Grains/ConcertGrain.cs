using Aerifloat.DTOs.Concerts;
using Aerifloat.Grains.Abstractions;
using Aerofloat.MediatRs.Commands.Concerts;
using MediatR;

namespace Aerifloat.Grains
{
    public class ConcertGrain : Grain, IConcertGrain
    {
        private readonly IMediator _mediator;
        public ConcertGrain(IMediator mediator)
        {
            _mediator = mediator;
        }
        

    public async Task<int> AddActsToConcert(int concertId, IEnumerable<CreateActDto> actDtos)
        {
            await Task.CompletedTask;
            return default;
        }

        public async Task<int> AddPerformersToConcert(int concertId, IEnumerable<CreatePerformerDto> performerDtos)
        {
            await Task.CompletedTask;
            return default;
        }

        public async Task<int> AddSessionToAct(long actId, IEnumerable<CreateSesionDto> sesionDtos)
        {
            await Task.CompletedTask;
            return default;
        }

        public async Task<int> CreateConcertAsync(CreateConcertDto concertDto)
        {
            var id = await _mediator.Send(new CreateConcertRequest 
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
