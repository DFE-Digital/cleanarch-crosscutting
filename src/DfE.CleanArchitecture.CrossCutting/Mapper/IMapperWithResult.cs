namespace DfE.CleanArchitecture.Common.CrossCutting.Mapper;
public interface IMapperWithResult<in TMapFrom, TMapTo>
{
    /// <summary>
    /// Defines the method call for mapping one type to another.
    /// </summary>
    /// <param name="input">
    /// The type to map from.
    /// </param>
    /// <returns>
    /// The type to map to.
    /// </returns>
    MappedResult<TMapTo> Map(TMapFrom input);
}

public record MappedResult<TResult>
{
    private readonly string _errorMessage;

    public MappedResult(MappingResultStatus status, TResult? result, Exception? ex = null)
    {
        if (status is MappingResultStatus.Successful && ex is not null)
        {
            throw new ArgumentException("Cannot have a successful mapping result with a captured exception", ex);
        }

        Result = result;
        Status = status;
        _errorMessage = ex?.Message ?? string.Empty;
    }

    public MappedResult(MappingResultStatus status, TResult? result, string? errorMessage)
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

public enum MappingResultStatus
{
    Successful,
    MapFromArgumentError,
    MapToError
}
