using Aerifloat.Domain.BoundedContext;
using Aerifloat.Domain.Domains;
using Aerifloat.Entities.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Aerifloat.Silo;

public static class BoundedContextRegister
{
    public static void AddBoundedContext(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped(typeof(IReadRepository<>), typeof(Repository<>));
        
        services.AddScoped<IConcertReadContext, ConcertReadContext>();
        services.AddScoped<IConcertCommandContext, ConcertCommandContext>();
    }
}
