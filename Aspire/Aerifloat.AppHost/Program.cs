
var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Aerifloat_Silo>("silo");

builder.AddProject<Projects.Aerifloat_Api_Backend>("api-backend");

builder.Build().Run();