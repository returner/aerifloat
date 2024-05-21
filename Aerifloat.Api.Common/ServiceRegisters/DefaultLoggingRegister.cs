using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Extensions.DependencyInjection;

namespace Aerifloat.Api.Common.ServiceRegisters
{
    public static class DefaultLoggingRegister
    {
        public static void AddDefaultLogging(this IServiceCollection services)
        {
            services.AddHttpLogging(logging =>
            {
                logging.LoggingFields = HttpLoggingFields.RequestPath | HttpLoggingFields.RequestBody |
                    HttpLoggingFields.RequestQuery | HttpLoggingFields.ResponseStatusCode | HttpLoggingFields.ResponseBody;
                //logging.RequestHeaders.Add("sec-ch-ua");
                //logging.ResponseHeaders.Add("MyResponseHeader");
                logging.MediaTypeOptions.AddText("application/javascript");
                logging.RequestBodyLogLimit = 4096;
                logging.ResponseBodyLogLimit = 4096;
                //logging.CombineLogs = true;
            });
        }
    }
}
