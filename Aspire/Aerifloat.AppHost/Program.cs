

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Aerifloat_Silo>("silo")
    .WithHttpEndpoint(port: 8123, isProxied: false);
    //.WithReplicas(10);

builder.AddProject<Projects.Aerifloat_Host_Api_Backend>("aerifloat-host-api-backend");

builder.Build().Run();