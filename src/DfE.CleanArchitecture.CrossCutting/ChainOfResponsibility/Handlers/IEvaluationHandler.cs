namespace DfE.CleanArchitecture.Common.CrossCutting.ChainOfResponsibility.Handlers;
public interface IEvaluationHandler<TIn>
{
    ValueTask<HandlerResult> HandleAsync(TIn input, CancellationToken ctx = default);
}
