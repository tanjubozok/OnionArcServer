namespace OnionArc.Application.Base;

public class BaseResult<T>
{
    public T? Data { get; init; }
    public List<Error>? Errors { get; init; }

    public bool IsSuccess => Errors == null || Errors.Count == 0;
    public bool IsFailure => !IsSuccess;

    public static BaseResult<T> Success(T data)
        => new() { Data = data };

    public static BaseResult<T> Failure(List<Error> errors)
        => new() { Errors = errors };

    public static BaseResult<T> Failure(ErrorType errorType, string errorMessage)
    {
        return new BaseResult<T>
        {
            Errors =
            [
                new Error
                {
                    Type = errorType,
                    ErrorMessage = errorMessage
                }
            ]
        };
    }

    public static BaseResult<T> Failure(ErrorType errorType, string propertyName, string errorMessage)
    {
        return new BaseResult<T>
        {
            Errors =
            [
                new Error
                {
                    Type = errorType,
                    PropertyName = propertyName,
                    ErrorMessage = errorMessage,
                }
            ]
        };
    }
}

public class Error
{
    public string? PropertyName { get; init; }
    public string ErrorMessage { get; init; }
    public ErrorType Type { get; init; }
}

public enum ErrorType
{
    Validation = 0,
    NotFound = 1,
    Conflict = 2,
    Unauthorized = 3,
    Forbidden = 4,
    InternalServerError = 5
}