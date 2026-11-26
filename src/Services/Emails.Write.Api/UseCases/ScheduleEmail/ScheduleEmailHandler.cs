using Emails.Write.Api.Domain.Entities;
using Emails.Write.Api.Domain.Repositories;
using Emails.Write.Api.Domain.ValueObjects;

namespace Emails.Write.Api.UseCases.ScheduleEmail;

public sealed class ScheduleEmailHandler(IEmailMessageRepository repository)
{
    public async Task<ScheduleEmailResult> HandleAsync(ScheduleEmailCommand command, CancellationToken ct)
    {
        var recipient = new EmailAddress(command.Recipient);
        var body = new EmailBody(command.Body);

        var message = EmailMessage.CreateScheduled(recipient, body, command.ScheduledAt);

        await repository.AddAsync(message, ct);
        await repository.SaveChangesAsync(ct);

        return new ScheduleEmailResult(message.Id, message.ScheduledAt);
    }
}
