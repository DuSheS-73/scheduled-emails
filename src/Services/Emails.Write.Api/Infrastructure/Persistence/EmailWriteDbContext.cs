using Emails.Write.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Emails.Write.Api.Infrastructure.Persistence;

public class EmailWriteDbContext(DbContextOptions<EmailWriteDbContext> options) : DbContext(options)
{
    public DbSet<EmailMessage> EmailMessages => Set<EmailMessage>();

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<DateTimeOffset>()
            .HaveConversion<DateTimeOffsetToUtcConverter>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmailWriteDbContext).Assembly);
    }
}

public class DateTimeOffsetToUtcConverter()
    : ValueConverter<DateTimeOffset, DateTimeOffset>(
        v => v.ToUniversalTime(),
        v => v.ToUniversalTime());
