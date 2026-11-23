namespace Emails.Write.Api.UseCases.ScheduleEmail;

public sealed record ScheduleEmailResult(Guid Id, DateTimeOffset ScheduledAt);
