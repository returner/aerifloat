using MinimalApi.Endpoint.Extensions;
using Orleans.Configuration;
using System.Reflection;
using Aerifloat.Api.Common.ServiceRegisters;
using Aerifloat.Api.Common.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Serilog;
var builder = WebApplication.CreateBuilder(args);


builder.AddServiceDefaults();

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

builder.Host.UseDefaultServiceProvider(opt =>
{
    opt.ValidateScopes = true;
    opt.ValidateOnBuild = true;
});

var config = new ConfigurationBuilder()
    .AddJsonFile($"appsettings.json", false)
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true)
    .AddEnvironmentVariables()
    .Build();
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(config));
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDefaultLogging();
builder.Services.AddEndpoints();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGenService("Backend", new Version(1, 0, 0), Assembly.GetExecutingAssembly().GetName().Name);

builder.Services.AddCorsPolicy([string.Empty]);
builder.Services.AddAntiforgery();
//var configJwt = builder.Configuration.GetAppValue<ConfigJwt>("JwtValues") ?? throw new NullReferenceException();
builder.Services.AddAuthorization();
builder.Services.
    AddAuthentication(o =>
    {
        o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    }).
    AddJwtBearer(o =>
    {
        //o.TokenValidationParameters = TokenHelper.GetTokenValidationParameters(configJwt.Issuer!, configJwt.SecretKey!);
    });

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseHttpLogging();
app.UseAntiforgery();
app.UseHttpsRedirection();
//app.UseSerilogRequestLogging();
app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapEndpoints();

app.Run();
