using Microsoft.Extensions.DependencyInjection;

namespace Aerifloat.Api.Common.ServiceRegisters
{
    public static class CorsRegisterServiceExtension
    {
        public static void AddCorsPolicy(this IServiceCollection services, IEnumerable<string> corsHosts)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy("Production", builder =>
                {
                    builder.SetIsOriginAllowedToAllowWildcardSubdomains()
                    .WithOrigins(corsHosts.ToArray())
                    .WithMethods("POST", "GET", "PUT", "DELETE")
                    .AllowAnyHeader();
                });
                opt.AddPolicy("Dev", builder =>
                {
                    builder
                    //.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
                    //.WithMethods("POST", "GET")
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });
        }
    }
}
