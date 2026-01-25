namespace DfE.CleanArchitecture.Common.CrossCutting.ChainOfResponsibility.Evaluator;
public sealed class Evaluator<TRequest> : IEvaluator<TRequest>
{
    private readonly IHandlerChain<
        TRequest,
            IEvaluationHandler<TRequest>> _handlerChain;

    public Evaluator(
        IHandlerChain<
            TRequest,
                IEvaluationHandler<TRequest>> handlerChain)
    {
        ArgumentNullException.ThrowIfNull(handlerChain);
        _handlerChain = handlerChain;
    }

    public async ValueTask EvaluateAsync(
        TRequest input, EvaluationOptions? options = null, CancellationToken ctx = default)
    {
        options ??= new();

        IExecutionStrategy<TRequest> strategy = new ChainOfResponsibilityStrategy<TRequest>();

        await strategy.ExecuteAsync(input, _handlerChain, ctx);
    }
}

