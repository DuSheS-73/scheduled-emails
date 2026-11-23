namespace Emails.Write.Api.Contracts;

public sealed record ScheduleEmailRequest(string Recipient, string Body, DateTimeOffset ScheduledAt);
