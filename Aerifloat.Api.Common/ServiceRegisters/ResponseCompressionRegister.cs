using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using System.IO.Compression;

namespace Aerifloat.Api.Common.ServiceRegisters
{
    public static class ResponseCompressionRegister
    {
        /// <summary>
        /// response 응답 압축
        /// </summary>
        /// <param name="services"></param>
        public static void AddCompression(this IServiceCollection services)
        {
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<BrotliCompressionProvider>();
                options.MimeTypes =
                    ResponseCompressionDefaults.MimeTypes.Concat(
                        new[] { "application/json", "text/plain", "image/svg+xml" });
            });
            services.Configure<BrotliCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Optimal;
            });
        }
    }
}
