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

    public static BaseResult<T> Failure(string propertyName, string errorMessage)
    {
        return new BaseResult<T>
        {
            Errors =
            [
                new Error
                {
                    PropertyName = propertyName,
                    ErrorMessage = errorMessage,
                    Type = ErrorType.Validation
                }
            ]
        };
    }

    public static BaseResult<T> NotFound(string resourceName, object identifier)
    {
        return new BaseResult<T>
        {
            Errors =
            [
                new Error
                {
                    PropertyName = null,
                    ErrorMessage = $"{resourceName} with identifier '{identifier}' was not found.",
                    Type = ErrorType.NotFound
                }
            ]
        };
    }

    public static BaseResult<T> NotFound(string message = "Resource not found.")
    {
        return new BaseResult<T>
        {
            Errors =
            [
                new Error
                {
                    PropertyName = null,
                    ErrorMessage = message,
                    Type = ErrorType.NotFound
                }
            ]
        };
    }

    public static BaseResult<T> Conflict(string message)
    {
        return new BaseResult<T>
        {
            Errors =
            [
                new Error
                {
                    PropertyName = null,
                    ErrorMessage = message,
                    Type = ErrorType.Conflict
                }
            ]
        };
    }

    public static BaseResult<T> Unauthorized(string message = "Unauthorized access.")
    {
        return new BaseResult<T>
        {
            Errors =
            [
                new Error
                {
                    PropertyName = null,
                    ErrorMessage = message,
                    Type = ErrorType.Unauthorized
                }
            ]
        };
    }

    public static BaseResult<T> Forbidden(string message = "Access forbidden.")
    {
        return new BaseResult<T>
        {
            Errors =
            [
                new Error
                {
                    PropertyName = null,
                    ErrorMessage = message,
                    Type = ErrorType.Forbidden
                }
            ]
        };
    }

    public TResult Match<TResult>(
        Func<T?, TResult> onSuccess,
        Func<List<Error>, TResult> onFailure)
    {
        return IsSuccess ? onSuccess(Data) : onFailure(Errors!);
    }
}

public class Error
{
    public string? PropertyName { get; init; }
    public string ErrorMessage { get; init; } = string.Empty;
    public ErrorType Type { get; init; } = ErrorType.Validation;
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