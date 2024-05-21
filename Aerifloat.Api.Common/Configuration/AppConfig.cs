using Opera.ApplicationCore.Configuration;

namespace Aerifloat.Api.Common.Configuration;

public record AppConfig
{
    public string? Environment { get; set; }
    public IEnumerable<string>? CorsOrigins { get; set; }
    public string? ConnectionStrings { get; set; }
    public ConfigJwt? JwtValues { get; set; }
}
