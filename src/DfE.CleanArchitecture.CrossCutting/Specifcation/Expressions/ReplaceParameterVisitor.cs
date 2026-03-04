using System.Linq.Expressions;

namespace DfE.CleanArchitecture.Common.CrossCutting.Specification.Expressions;
internal sealed class ReplaceParameterVisitor : ExpressionVisitor
{
    private readonly ParameterExpression _oldParam;
    private readonly ParameterExpression _newParam;

    public ReplaceParameterVisitor(ParameterExpression oldParam, ParameterExpression newParam)
    {
        _oldParam = oldParam;
        _newParam = newParam;
    }

    protected override Expression VisitParameter(ParameterExpression node)
        => node == _oldParam ? _newParam : base.VisitParameter(node);
}
