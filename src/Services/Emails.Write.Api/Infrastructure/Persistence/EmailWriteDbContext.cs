using Emails.Write.Api.Domain.Entities;
using Infrastructure.Persistence.PostgreSql;
using Microsoft.EntityFrameworkCore;

namespace Emails.Write.Api.Infrastructure.Persistence;

public class EmailWriteDbContext(DbContextOptions<EmailWriteDbContext> options) : PostgreSqlDbContext(options)
{
    public DbSet<EmailMessage> EmailMessages => Set<EmailMessage>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmailWriteDbContext).Assembly);
    }
}
