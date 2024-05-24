
namespace Aerifloat.Domain.DTOs.Concerts.Commands
{
    public record CreateConcertDto
    {
        public required string Title { get; init; }
        public string? Description { get; init; }
        public DateTime StartAt { get; init; }
        public DateTime EndAt { get; init; }
    }
}
