using Aerifloat.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;

namespace Aerifloat.Api.Common.ServiceRegisters
{
    public static class DbContextRegister
    {
        public static void AddOperaDbContext(this IServiceCollection services, string? connectionString, Version? version)
        {
            // In Memory DB 사용할때
            if (connectionString!.Contains("InMemoryDb"))
            {
                var dbName = "OperaApiTestDb";

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
                        .UseMySql(connectionString, new MySqlServerVersion(version), (o) =>
                        {
                            o.MigrationsHistoryTable(HistoryRepository.DefaultTableName);
                        })
                        .EnableSensitiveDataLogging()
                        .EnableDetailedErrors();
                });
            }
        }
    }
}
