using Aerifloat.Grains.Dtos.Grains.Concerts;

namespace Aerifloat.Grains.Abstractions
{
    public interface IConcertGrain : IGrainWithIntegerKey
    {
        Task<int> CreateConcertAsync(GrainCreateConcertDto concertDto);
        Task<int> AddPerformersToConcert(int concertId, IEnumerable<GrainCreatePerformerDto> performerDtos);
        Task<int> AddActsToConcert(int concertId, IEnumerable<GrainCreateActDto> actDtos);
        Task<int> AddSessionToAct(long actId, IEnumerable<GrainCreateSesionDto> sesionDtos);
    }
}
