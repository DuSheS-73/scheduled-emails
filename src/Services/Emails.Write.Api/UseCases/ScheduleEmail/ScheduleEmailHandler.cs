using Emails.Write.Api.Domain.Repositories;

namespace Emails.Write.Api.UseCases.ScheduleEmail;

public sealed class ScheduleEmailHandler(IEmailMessageRepository repository)
{
    public async Task<ScheduleEmailResult> HandleAsync(ScheduleEmailCommand command, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
