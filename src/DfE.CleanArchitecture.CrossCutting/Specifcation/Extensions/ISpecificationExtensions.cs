namespace DfE.CleanArchitecture.Common.CrossCutting.Specifcation.Extensions;
internal static class ISpecificationExtensions
{
    internal static ISpecification<T> And<T>(this ISpecification<T> left, ISpecification<T> right)
    {
        ArgumentNullException.ThrowIfNull(left);
        ArgumentNullException.ThrowIfNull(right);
        return new AndSpecificaton<T>(left, right);
    }
}
