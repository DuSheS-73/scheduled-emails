using Domain.Exceptions;
using Domain.Helpers;
using Domain.ValueObjects;

namespace Emails.Write.Api.Domain.ValueObjects;

public sealed record EmailBody : BaseValueObject
{
    public EmailBody(string value)
    {
        Value = value.Trim();

        CheckPolicies();
    }

    public string Value { get; } = default!;

    protected override void CheckPolicies()
    {
        if (string.IsNullOrWhiteSpace(Value))
            throw new DomainException("Body is required.");

        if (Value.Length > DomainConstValues.EMAIL_ADDRESS_MAX_LENGTH)
            throw new DomainException($"Body must be at most {DomainConstValues.EMAIL_BODY_MAX_LENGTH} characters.");
    }

    public override string ToString() => Value;
}
