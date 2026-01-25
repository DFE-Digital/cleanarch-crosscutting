using DfE.CleanArchitecture.Common.CrossCutting.ChainOfResponsibility.Evaluator.Options;

namespace DfE.CleanArchitecture.Common.CrossCutting.ChainOfResponsibility.Evaluator;
public interface IEvaluator<TIn>
{
    ValueTask EvaluateAsync(TIn input, EvaluationOptions? options = null, CancellationToken ctx = default);
}
