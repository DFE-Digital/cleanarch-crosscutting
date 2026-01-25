using DfE.CleanArchitecture.Common.CrossCutting.ChainOfResponsibility.Handlers;

namespace DfE.CleanArchitecture.Common.CrossCutting.ChainOfResponsibility.Chain;
public sealed class HandlerChain<TContext, THandler> : IHandlerChain<TContext, THandler>
    where THandler : IEvaluationHandler<TContext>
{
    public HandlerChain(IEnumerable<THandler> handlers)
    {
        ArgumentNullException.ThrowIfNull(handlers);

        if (!handlers.Any())
        {
            throw new ArgumentException("No handlers registered");
        }

        Handlers = handlers.ToList().AsReadOnly();
    }

    public IReadOnlyList<THandler> Handlers { get; }
}
