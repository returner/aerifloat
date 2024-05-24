using Aerifloat.Silo;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Orleans.Configuration;

IHostBuilder builder = Host.CreateDefaultBuilder(args)
    .UseOrleans(silo =>
    {
        silo.UseDashboard(options => 
        {
            options.Port = 8123;
        });
        silo.UseLocalhostClustering()
        .ConfigureServices(services => 
        { 
            services.AddAppDbContext("Host=localhost;Database=aerifloat;Username=dev;Password=1234");
            services.AddBoundedContext();
        })
            .Configure<ClusterOptions>(options =>
            {
                options.ClusterId = "dev";
                options.ServiceId = "HelloWorldApp";
            })
            .Configure<EndpointOptions>(options =>
            {
                options.AdvertisedIPAddress = System.Net.IPAddress.Loopback;
            })
            .ConfigureLogging(logging => logging.AddConsole());
    })
    .UseConsoleLifetime();

using IHost host = builder.Build();

await host.RunAsync();