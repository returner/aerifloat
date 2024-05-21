$env:ASPNETCORE_ENVIRONMENT = 'Development'
dotnet ef database update -p ../Aerifloat.Infrastructure/Aerifloat.Infrastructure.csproj -s ../Aerifloat.Api.Backend/Aerifloat.Api.Backend.csproj --context AppDbContext

