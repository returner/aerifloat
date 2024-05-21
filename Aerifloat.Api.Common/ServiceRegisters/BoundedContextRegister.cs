using Aerifloat.Core.Repositories;
using Aerifloat.Infrastructure.BoundedContext;
using Aerifloat.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Aerifloat.Api.Common.ServiceRegisters
{
    public static class BoundedContextRegister
    {
        public static void AddBoundedContext(this IServiceCollection services)
        {
            AddRepository(services);
            services.AddScoped<ConcertContext>();
        }

        private static void AddRepository(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IReadRepository<>), typeof(Repository<>));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        }
    }
}
