using Aerifloat.Grains.Abstractions;
using Orleans.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseOrleansClient(client =>
{
    client.UseLocalhostClustering()
    .Configure<ClusterOptions>(options => 
    { 
        options.ClusterId = "dev"; 
        options.ServiceId = "HelloWorldApp"; 
    });
})
    .ConfigureLogging(logging => logging.AddConsole())
    .UseConsoleLifetime();

builder.AddServiceDefaults();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", async (IClusterClient client) =>
{
    var friend = client.GetGrain<IHello>(0);
    string response = await friend.SayHello();
    return response;
})
.WithName("SayHello")
.WithOpenApi();

app.Run();
