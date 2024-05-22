namespace Aerifloat.Api.Endpoints.Concerts.Payloads
{
    public record SessionPayload
    {
        public int Order { get; set; }
        public required string Title { get; set; }
    }
}
