namespace Emails.Write.Api.Contracts;

public sealed record ScheduleEmailResponse(Guid Id, DateTimeOffset ScheduledAt);