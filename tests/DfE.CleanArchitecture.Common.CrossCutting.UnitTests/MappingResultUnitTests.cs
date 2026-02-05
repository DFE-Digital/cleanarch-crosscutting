using DfE.CleanArchitecture.Common.CrossCutting.Mapper;

namespace DfE.CleanArchitecture.Common.CrossCutting.UnitTests;
public sealed class MappedResultTests
{
    [Fact]
    public void Constructor_Throws_When_Successful_With_Exception()
    {
        // Arrange
        Exception ex = new InvalidOperationException("exception");

        // Act
        Func<MappedResult<string>> act =
            () => new(
                    MappingResultStatus.Successful,
                    "value",
                    ex);

        // Assert
        Assert.Throws<ArgumentException>(act);
    }

    [Fact]
    public void Constructor_Throws_When_Successful_With_ErrorMessage()
    {
        // Arrange
        string errorMessage = "Should not pass";

        // Act
        Func<MappedResult<string>> act =
            () => new(
                    MappingResultStatus.Successful,
                    "value",
                    errorMessage);

        // Assert
        Assert.Throws<ArgumentException>(act);
    }

    [Fact]
    public void Success_Returns_Expected_Values()
    {
        // Arrange
        string expected = "mapped";

        // Act
        MappedResult<string> result = MappedResult<string>.Success(expected);

        // Assert
        Assert.Equal(MappingResultStatus.Successful, result.Status);
        Assert.Equal(expected, result.Result);
        Assert.True(result.HasResult);
        Assert.Equal(string.Empty, result.ErrorMessage);
        Assert.Null(result.Exception);
    }


    [Fact]
    public void RequestError_Sets_Status_And_ErrorMessage()
    {
        // Arrange
        string message = "invalid-data";

        // Act
        MappedResult<string> result = MappedResult<string>.RequestError(message);

        // Assert
        Assert.Equal(MappingResultStatus.MapFromArgumentError, result.Status);
        Assert.False(result.HasResult);
        Assert.Null(result.Result);
        Assert.Equal(message, result.ErrorMessage);
        Assert.Null(result.Exception);
    }

    [Fact]
    public void RequestError_Allows_Empty_ErrorMessage()
    {
        // Arrange
        string message = string.Empty;

        // Act
        MappedResult<string> result = MappedResult<string>.RequestError(message);

        // Assert
        Assert.Equal(MappingResultStatus.MapFromArgumentError, result.Status);
        Assert.False(result.HasResult);
        Assert.Equal(string.Empty, result.ErrorMessage);
    }

    [Fact]
    public void MappingError_Sets_Status_And_Exception()
    {
        // Arrange
        Exception ex = new InvalidOperationException("map fail");

        // Act
        MappedResult<string> result = MappedResult<string>.MappingError(ex);

        // Assert
        Assert.Equal(MappingResultStatus.MapToError, result.Status);
        Assert.False(result.HasResult);
        Assert.Null(result.Result);
        Assert.Equal("map fail", result.ErrorMessage);
        Assert.Equal(ex, result.Exception);
    }

    [Fact]
    public void MappingError_Handles_Null_Exception_Message()
    {
        // Arrange
        Exception ex = new(null);

        // Act
        MappedResult<string> result = MappedResult<string>.MappingError(ex);

        // Assert
        Assert.Equal(MappingResultStatus.MapToError, result.Status);
        Assert.Equal(ex.Message, result.ErrorMessage);
    }

    [Fact]
    public void HasResult_False_When_Successful_But_Result_Is_Null()
    {
        // Arrange
        MappedResult<string> result = new(
                MappingResultStatus.Successful,
                result: null,
                errorMessage: null);

        // Act Assert
        Assert.False(result.HasResult);
    }

    [Fact]
    public void ErrorMessage_Returns_Empty_When_HasResult_True()
    {
        // Arrange
        MappedResult<string> result = MappedResult<string>.Success("ok");

        // Act Assert
        Assert.True(result.HasResult);
        Assert.Equal(string.Empty, result.ErrorMessage);
    }

    [Fact]
    public void ErrorMessage_Not_Empty_When_HasResult_False()
    {
        // Arrange
        MappedResult<string> result = MappedResult<string>.RequestError("ERROR");

        // Act Assert
        Assert.False(result.HasResult);
        Assert.Equal("ERROR", result.ErrorMessage);
    }
}
