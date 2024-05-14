
var builder = DistributedApplication.CreateBuilder(args);


// add orleans
//var storage = builder.AddAzureStorage("storage").RunAsEmulator();
//var clusteringTable = storage.AddTables("clustering");
//var grainStorage = storage.AddBlobs("grain-state");

//var orleans = builder.AddOrleans("default")
//    .WithDevelopmentClustering()
//    .WithMemoryGrainStorage("Default");
//    //.WithClustering()
////    .WithGrainStorage("Default", grainStorage);

builder.AddProject<Projects.Silos>("silo");
//.WithReference(orleans)
//.WithReplicas(3);
//var abstractProject = builder.AddProject<Projects.Abstractions>("abstraction");

builder.AddProject<Projects.Endpoints>("endpoints");
    //.WithExternalHttpEndpoints();
    //.WithReference(abstractProject);

//.WithReference(orleans.AsClient())
//.WithExternalHttpEndpoints()
//.WithReplicas(3);

builder.Build().Run();