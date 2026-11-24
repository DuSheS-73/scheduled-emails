namespace Domain.ValueObjects;

public abstract record BaseValueObject
{
    /// <summary>
    /// Check policies for each value object by itself
    /// Policies are kind of validation that the system know how to deal with
    /// </summary>
    protected abstract void CheckPolicies();
}
