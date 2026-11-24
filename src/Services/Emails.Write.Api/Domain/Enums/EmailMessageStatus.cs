namespace Emails.Write.Api.Domain.Enums;

public enum EmailMessageStatus : short
{
    Pending = 0,
    Sending,
    Sent,
    Failed
}
