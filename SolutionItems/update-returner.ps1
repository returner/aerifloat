$env:ASPNETCORE_ENVIRONMENT = 'returner'
dotnet ef database update -p ../Aerifloat.Entities/Aerifloat.Entities.csproj -s ../Aerifloat.Silo/Aerifloat.Silo.csproj --context AppDbContext

