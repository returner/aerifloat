namespace Aerifloat.Api.Common.Configuration;

public class ConfigJwt
{
    public string? Issuer { get; set; }

    public string? SecretKey { get; set; }
    public int ExpireMinutes { get; set; }
}