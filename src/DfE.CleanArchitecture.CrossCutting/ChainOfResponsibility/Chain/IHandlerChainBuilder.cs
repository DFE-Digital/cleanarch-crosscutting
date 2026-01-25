using DfE.CleanArchitecture.Common.CrossCutting.ChainOfResponsibility.Handlers;

namespace DfE.CleanArchitecture.Common.CrossCutting.ChainOfResponsibility.Chain;
public interface IHandlerChainBuilder<TInput, THandler>
    where THandler : IEvaluationHandler<TInput>
{
    IHandlerChainBuilder<TInput, THandler> ChainNext(THandler handler);
    IHandlerChain<TInput, THandler> Build();
}
