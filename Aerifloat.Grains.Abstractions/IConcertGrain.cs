using Aerifloat.Grains.Dtos.Grains.Concerts;

namespace Aerifloat.Grains.Abstractions
{
    public interface IConcertGrain : IGrainWithIntegerKey
    {
        Task<int> CreateConcertAsync(CreateConcertDto concertDto);
        Task<int> AddPerformersToConcert(int concertId, IEnumerable<CreatePerformerDto> performerDtos);
        Task<int> AddActsToConcert(int concertId, IEnumerable<CreateActDto> actDtos);
        Task<int> AddSessionToAct(long actId, IEnumerable<CreateSesionDto> sesionDtos);
    }
}
