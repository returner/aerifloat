using Orleans;

namespace Aerifloat.DTOs.Concerts
{
    [GenerateSerializer]
    [Alias("Aerifloat.DTOs.Concerts.CreateConcertDto")]
    public class CreateConcertDto
    {
        [Id(0)]
        public required string Title { get; set; }
        [Id(1)]
        public string? Description { get; set; }
        [Id(2)]
        public required DateTime StartAt { get; set; }
        [Id(3)]
        public required DateTime EndAt { get; set; }
    }
}
