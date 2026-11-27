using Infrastructure.Persistence.PostgreSql;
using Microsoft.EntityFrameworkCore;

namespace Emails.Sender.Worker.Infrastructure.Persistence;

internal class EmailSenderDbContext(DbContextOptions<EmailSenderDbContext> options) : PostgreSqlDbContext(options)
{
    //public DbSet<EmailMessage> EmailMessages => Set<EmailMessage>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmailSenderDbContext).Assembly);
    }
}
