using System.Linq.Expressions;

namespace DfE.CleanArchitecture.Common.CrossCutting.Specification;
public interface ISpecification<TInput>
{
    Expression<Func<TInput, bool>> ToExpression();
    bool IsSatisfiedBy(TInput input);
}
