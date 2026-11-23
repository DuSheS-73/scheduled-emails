using Emails.Write.Api.Domain.Entities;

namespace Emails.Write.Api.Domain.Repositories;

public interface IEmailMessageRepository
{
    Task AddAsync(EmailMessage message, CancellationToken ct);
    Task<int> SaveChangesAsync(CancellationToken ct);
}
