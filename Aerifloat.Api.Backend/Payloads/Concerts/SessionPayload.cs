namespace Aerifloat.Api.Backend.Payloads.Concerts
{
    public record SessionPayload : IPayload
    {
        public int Order { get; set; }
        public required string Title { get; set; }
    }
}
