namespace DfE.CleanArchitecture.Common.CrossCutting.Mapper;
public record MappedResult<TResult> : IMappedResult<TResult>
{
    private readonly string _errorMessage;

    internal MappedResult(MappingResultStatus status, TResult? result, Exception? ex = null)
    {
        if (status is MappingResultStatus.Successful && ex is not null)
        {
            throw new ArgumentException("Cannot have a successful mapping result with a captured exception", ex);
        }

        Result = result;
        Status = status;
        Exception = ex;
        _errorMessage = ex?.Message ?? string.Empty;
    }

    internal MappedResult(MappingResultStatus status, TResult? result, string? errorMessage)
    {
        if (status is MappingResultStatus.Successful && !string.IsNullOrWhiteSpace(errorMessage))
        {
            throw new ArgumentException("Cannot create a successful mapping result with an error message");
        }

        Result = result;
        Status = status;
        _errorMessage = errorMessage ?? string.Empty;
    }

    public MappingResultStatus Status { get; init; }
    public TResult? Result { get; }
    public Exception? Exception { get; }
    public bool HasResult => Result is not null && Status == MappingResultStatus.Successful;
    public string ErrorMessage => HasResult ? string.Empty : _errorMessage;

    public static MappedResult<TResult> Success(TResult result) => new(MappingResultStatus.Successful, result);

    public static MappedResult<TResult> RequestError(string errorMessage) => new(MappingResultStatus.MapFromArgumentError, default, errorMessage);

    public static MappedResult<TResult> MappingError(Exception ex) => new(MappingResultStatus.MapToError, default(TResult), ex);
}
