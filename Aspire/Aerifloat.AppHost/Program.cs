
using Microsoft.Extensions.Options;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Aerifloat_Silo>("silo");
    //.WithHttpEndpoint(port:8123, isProxied:false)
    //.WithReplicas(10);

builder.AddProject<Projects.Aerifloat_Api_Backend>("api-backend");

builder.Build().Run();