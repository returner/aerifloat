using System.Text.Json.Serialization;
using System.Text.Json;

namespace Aerifloat.Api.Common.Converters
{
    public class TimeSpanConverter : JsonConverter<TimeSpan>
    {
        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var timeString = reader.GetString() ?? throw new InvalidCastException();
            return TimeSpan.Parse(timeString); // Adjust this as necessary for your time format
        }

        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
