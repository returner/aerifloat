namespace Aerifloat.Api.Endpoints.Concerts.Payloads
{
    public record ActPayload
    {
        public required string Title { get; set; }
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan StartTime { get; set; }
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan EndTime { get; set; }
        public IEnumerable<SessionPayload>? Sessions { get; set; }
    }
}
