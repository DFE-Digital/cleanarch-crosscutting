namespace DfE.CleanArchitecture.Common.CrossCutting.Mapper;
public interface IMappedResult<TResult>
{
    MappingResultStatus Status { get; }
    TResult? Result { get; }
    bool HasResult { get; }
    string ErrorMessage { get; }
    Exception? Exception { get; }
}
