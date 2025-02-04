using Microsoft.EntityFrameworkCore;
using Simpoll.Blazor.Data.Models;

namespace Simpoll.Blazor.Data;

public class PollContext(DbContextOptions<PollContext> options) : DbContext(options)
{
    public DbSet<Poll> Polls { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Poll>();
    }
}