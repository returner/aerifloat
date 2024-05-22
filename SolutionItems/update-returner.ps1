$env:ASPNETCORE_ENVIRONMENT = 'returner'
dotnet ef database update -p ../Aerifloat.Repositories/Aerifloat.Repositories.csproj -s ../Aerifloat.Silo/Aerifloat.Silo.csproj --context AppDbContext

