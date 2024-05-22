namespace Aerifloat.Api.Backend.Payloads.Concerts
{
    public record CreateConcertPayload : IPayload
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required DateTime StartAt { get; set; }
        public required DateTime EndAt { get; set; }
        public IEnumerable<ActPayload>? Acts { get; set; }
        public IEnumerable<PerformerPayload>? Performers { get; set; }
    }
}
