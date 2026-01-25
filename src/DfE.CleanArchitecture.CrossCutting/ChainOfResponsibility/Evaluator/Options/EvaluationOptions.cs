namespace DfE.CleanArchitecture.Common.CrossCutting.ChainOfResponsibility.Evaluator.Options;
public sealed class EvaluationOptions
{
    public ChainExecutionMode Mode { get; init; } = ChainExecutionMode.ChainOfResponsibility;
}
