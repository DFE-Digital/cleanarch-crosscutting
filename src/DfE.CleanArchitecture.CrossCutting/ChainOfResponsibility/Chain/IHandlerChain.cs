using DfE.CleanArchitecture.Common.CrossCutting.ChainOfResponsibility.Handlers;

namespace DfE.CleanArchitecture.Common.CrossCutting.ChainOfResponsibility.Chain;
public interface IHandlerChain<TRequest, out THandler>
    where THandler : IEvaluationHandler<TRequest>
{
    IReadOnlyList<THandler> Handlers { get; }
}
