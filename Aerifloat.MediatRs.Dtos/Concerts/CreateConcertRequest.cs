namespace Aerifloat.DTOs.Context.Concerts
{
    /// <summary>
    /// Represents a request to create a concert.
    /// </summary>
    public record CreateConcertRequest : IRequest<int>
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required DateTime StartAt { get; set; }
        public required DateTime EndAt { get; set; }
    }
}
