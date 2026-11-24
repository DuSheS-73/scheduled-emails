using Emails.Write.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Emails.Write.Api.Infrastructure.Persistence;

public class EmailWriteDbContext(DbContextOptions<EmailWriteDbContext> options) : DbContext(options)
{
    public DbSet<EmailMessage> EmailMessages => Set<EmailMessage>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmailWriteDbContext).Assembly);
    }
}
