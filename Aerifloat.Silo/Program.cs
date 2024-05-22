using Aerifloat.Silo;
using Aerofloat.MediatRs;
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
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<MediatorRegister>());
            services.AddAppDbContext("server=localhost;user=platform_user;password=platform_user!;port=3306;database=Opera;", new Version(8,0,33));
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

