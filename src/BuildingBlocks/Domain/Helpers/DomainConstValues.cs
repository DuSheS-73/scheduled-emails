using System.Text.RegularExpressions;

namespace Domain.Helpers;

public static class DomainConstValues
{
    public static readonly Regex EMAIL_ADDRESS_PATTERN = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled | RegexOptions.CultureInvariant);
    public const int EMAIL_ADDRESS_MAX_LENGTH = 254;
    public const int EMAIL_BODY_MAX_LENGTH = 10_000;
    public const int EMAIL_MAX_FUTURE_DAYS = 365;
}
