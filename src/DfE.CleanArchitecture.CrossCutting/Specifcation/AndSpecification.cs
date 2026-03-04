using System.Linq.Expressions;
using DfE.CleanArchitecture.Common.CrossCutting.Specification.Expressions;

namespace DfE.CleanArchitecture.Common.CrossCutting.Specification;
internal sealed class AndSpecification<T> : ISpecification<T>
{
    public AndSpecification(ISpecification<T> left, ISpecification<T> right)
    {
        ArgumentNullException.ThrowIfNull(left);
        Left = left;

        ArgumentNullException.ThrowIfNull(right);
        Right = right;
    }

    public bool IsSatisfiedBy(T input) => Left.IsSatisfiedBy(input) && Right.IsSatisfiedBy(input);

    public ISpecification<T> Left { get; }
    public ISpecification<T> Right { get; }

    public Expression<Func<T, bool>> ToExpression() => ExpressionRebinder.Rebind(Left.ToExpression(), Right.ToExpression(), Expression.AndAlso);
}
