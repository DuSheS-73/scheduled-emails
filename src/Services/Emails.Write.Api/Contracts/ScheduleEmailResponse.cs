namespace Emails.Write.Api.Contracts;

public sealed record ScheduleEmailResponse(string Id, DateTimeOffset ScheduledAt);