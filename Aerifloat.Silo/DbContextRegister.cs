using Aerifloat.Entities.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Aerifloat.Silo;

public static class DbContextRegister
{
    public static void AddAppDbContext(this IServiceCollection services, string? connectionString, Version? version = default)
    {
        // In Memory DB 사용할때
        if (connectionString!.Contains("InMemoryDb"))
        {
            var dbName = "AppApiTestDb";

            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();
            services.AddDbContext<AppDbContext>(opts =>
            {
                opts.UseInMemoryDatabase(dbName);
                opts.UseInternalServiceProvider(serviceProvider);
            });
        }
        else
        {
            services.AddDbContext<AppDbContext>(opts =>
            {
                opts
                    .UseNpgsql(connectionString)
                    //.UseMySql(connectionString, new MySqlServerVersion(version), (o) =>
                    //{
                    //    o.MigrationsHistoryTable(HistoryRepository.DefaultTableName);
                    //})
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            });
        }
    }
}
