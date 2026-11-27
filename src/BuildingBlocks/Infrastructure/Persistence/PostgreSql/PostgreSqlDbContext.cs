using Infrastructure.Persistence.PostgreSql.Converters;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.PostgreSql;

public abstract class PostgreSqlDbContext : DbContext
{
    protected PostgreSqlDbContext(DbContextOptions<PostgreSqlDbContext> options)
        : base(options)
    {
    }

    protected PostgreSqlDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<DateTimeOffset>()
            .HaveConversion<DateTimeOffsetToUtcConverter>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
