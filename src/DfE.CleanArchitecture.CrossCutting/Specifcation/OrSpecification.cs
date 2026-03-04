using System.Linq.Expressions;
using DfE.CleanArchitecture.Common.CrossCutting.Specification.Expressions;

namespace DfE.CleanArchitecture.Common.CrossCutting.Specification;
internal sealed class OrSpecification<TInput> : ISpecification<TInput>
{
    public OrSpecification(ISpecification<TInput> left, ISpecification<TInput> right)
    {
        ArgumentNullException.ThrowIfNull(left);
        Left = left;

        ArgumentNullException.ThrowIfNull(right);
        Right = right;
    }

    public ISpecification<TInput> Left { get; }
    public ISpecification<TInput> Right { get; }

    public bool IsSatisfiedBy(TInput input)
        => Left.IsSatisfiedBy(input) || Right.IsSatisfiedBy(input);

    public Expression<Func<TInput, bool>> ToExpression()
        => ExpressionRebinder.Rebind(Left.ToExpression(), Right.ToExpression(), Expression.OrElse);
}
