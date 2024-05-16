
var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Aerifloat_Silo>("silo");

builder.AddProject<Projects.Endpoints>("endpoints");

builder.Build().Run();