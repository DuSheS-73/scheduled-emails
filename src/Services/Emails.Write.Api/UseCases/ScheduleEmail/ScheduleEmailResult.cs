namespace Emails.Write.Api.UseCases.ScheduleEmail;

public sealed record ScheduleEmailResult(string Id, DateTimeOffset ScheduledAt);
