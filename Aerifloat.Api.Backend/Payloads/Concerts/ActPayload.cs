
using Aerifloat.Api.Common.Converters;
using System.Text.Json.Serialization;

namespace Aerifloat.Api.Backend.Payloads.Concerts
{
    public record ActPayload : IPayload
    {
        public required string Title { get; set; }
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan StartTime { get; set; }
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan EndTime { get; set; }
        public IEnumerable<SessionPayload>? Sessions { get; set; }
    }
}
