using DfE.CleanArchitecture.Common.CrossCutting.ChainOfResponsibility.Chain;
using DfE.CleanArchitecture.Common.CrossCutting.ChainOfResponsibility.Handlers;

namespace DfE.CleanArchitecture.Common.CrossCutting.ChainOfResponsibility.Evaluator.ExecutionStrategy;
public interface IExecutionStrategy<TIn>
{
    ValueTask ExecuteAsync(
        TIn input,
        IHandlerChain<TIn, IEvaluationHandler<TIn>> chain,
        CancellationToken token = default
    );
}
