using Emails.Write.Api.Domain.Entities;
using Emails.Write.Api.Domain.Repositories;

namespace Emails.Write.Api.Infrastructure.Persistence.Repositories;

public sealed class EmailMessageRepository(EmailWriteDbContext dbContext) : IEmailMessageRepository
{
    public Task AddAsync(EmailMessage message, CancellationToken ct)
    {
        dbContext.EmailMessages.Add(message);
        return Task.CompletedTask;
    }

    public Task<int> SaveChangesAsync(CancellationToken ct)
    {
        return dbContext.SaveChangesAsync(ct);
    }
}
