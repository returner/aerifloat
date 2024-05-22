namespace Aerifloat.Api.Backend.Payloads.Concerts
{
    public record PerformerPayload : IPayload
    {
        public required string Name { get; set; }
    }
}
