using Domain.Entities;
using Domain.Exceptions;
using Domain.Helpers;
using Emails.Write.Api.Domain.Enums;
using Emails.Write.Api.Domain.ValueObjects;

namespace Emails.Write.Api.Domain.Entities;

public sealed class EmailMessage : BaseEntity
{
    public EmailAddress Recipient { get; private set; } = default!;
    public EmailBody Body { get; private set; } = default!;
    public DateTimeOffset ScheduledAt { get; private set; }
    public EmailMessageStatus Status { get; private set; }
    public int Attempts { get; private set; }
    public string? LastError { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }
    public DateTimeOffset UpdatedAt { get; private set; }

    // Поля, задействованные воркером — присутствуют в схеме с самого начала,
    // чтобы воркер можно было добавить без миграции схемы.
    public string? LockedBy { get; private set; }
    public DateTimeOffset? LockedUntil { get; private set; }

    // Используется как concurrency token (Npgsql xmin)
    public uint Version { get; private set; }

    public static EmailMessage CreateScheduled(EmailAddress recipient, EmailBody body, DateTimeOffset scheduledAt)
    {
        var now = DateTimeOffset.UtcNow;

        if (scheduledAt <= now)
            throw new DomainException("ScheduledAt must be in the future.");

        if (scheduledAt > now.AddDays(DomainConstValues.EMAIL_MAX_FUTURE_DAYS))
            throw new DomainException($"ScheduledAt cannot be more than {DomainConstValues.EMAIL_MAX_FUTURE_DAYS} days ahead.");

        return new EmailMessage
        {
            Recipient = recipient,
            Body = body,
            ScheduledAt = scheduledAt,
            Status = EmailMessageStatus.Pending,
            Attempts = 0,
            CreatedAt = now,
            UpdatedAt = now
        };
    }
}
