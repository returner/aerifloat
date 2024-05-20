using Aerifloat.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aerifloat.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Act> Acts { get; set; }
    public DbSet<Concert> Concerts { get; set; }
    public DbSet<Performer> Performsers { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<Venue> Venues { get; set; }
}
