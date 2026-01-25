using System.Linq.Expressions;

namespace DfE.CleanArchitecture.Common.CrossCutting.Specifcation;
public interface ISpecification<T>
{
    Expression<Func<T, bool>> ToExpression();
    bool IsSatisfiedBy(T input);
}
