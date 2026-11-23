namespace Emails.Write.Api.UseCases.ScheduleEmail;

public sealed record ScheduleEmailCommand(string Recipient, string Body, DateTimeOffset ScheduledAt);
