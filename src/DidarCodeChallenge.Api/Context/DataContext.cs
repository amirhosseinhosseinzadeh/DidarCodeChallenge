using DidarCodeChallenge.Api.Domains;
using Microsoft.EntityFrameworkCore;

namespace DidarCodeChallenge.Api.Context;

public class DataContext : DbContext
{
    private readonly DbContextOptions<DataContext> _options;
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
        _options = options;
    }

    public DbSet<Request> Requests { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Request>()
            .HasKey(nameof(Request.Id));
    }
}