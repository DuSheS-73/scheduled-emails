namespace Domain.ValueObjects;

public abstract class BaseValueObject
{
    public override bool Equals(object obj)
    {
        if (obj == null || obj.GetType() != GetType())
            return false;

        return GetEqualityComponents().SequenceEqual(((BaseValueObject)obj).GetEqualityComponents());
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents().Select(x => x != null ? x.GetHashCode() : 0).Aggregate((x, y) => x ^ y);
    }

    protected static bool EqualOperator(BaseValueObject left, BaseValueObject right)
    {
        if (left is null ^ right is null)
            return false;

        return left is null || left.Equals(right);
    }

    protected static bool NotEqualOperator(BaseValueObject left, BaseValueObject right)
    {
        return !EqualOperator(left, right);
    }

    protected abstract IEnumerable<object> GetEqualityComponents();

    /// <summary>
    /// Check policies for each value object by itself
    /// Policies are kind of validation that the system know how to deal with
    /// </summary>
    protected abstract void CheckPolicies();
}
