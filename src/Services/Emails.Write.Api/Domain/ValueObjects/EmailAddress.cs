using Domain.Exceptions;
using Domain.Helpers;
using Domain.ValueObjects;

namespace Emails.Write.Api.Domain.ValueObjects;

public sealed record EmailAddress : BaseValueObject
{
    public EmailAddress(string value)
    {
        Value = value.Trim().ToLowerInvariant();

        CheckPolicies();
    }

    public string Value { get; } = default!;

    protected override void CheckPolicies()
    {
        if (string.IsNullOrWhiteSpace(Value))
            throw new DomainException("Recipient email is required.");

        if (Value.Length > DomainConstValues.EMAIL_ADDRESS_MAX_LENGTH)
            throw new DomainException($"Recipient email must be at most {DomainConstValues.EMAIL_ADDRESS_MAX_LENGTH} characters.");

        if (!DomainConstValues.EMAIL_ADDRESS_PATTERN.IsMatch(Value))
            throw new DomainException("Recipient email has invalid format.");
    }

    public override string ToString() => Value;
}
