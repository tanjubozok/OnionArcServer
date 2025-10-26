namespace OnionArc.Application.Results;

public class TResult<T>
{
    public T? Data { get; init; }
    public List<Error>? Errors { get; init; }

    public bool IsSuccess => Errors == null || Errors.Count == 0;
    public bool IsFailure => !IsSuccess;

    public static TResult<T> Success(T data)
        => new() { Data = data };

    public static TResult<T> Failure(List<Error> errors)
        => new() { Errors = errors };

    public static TResult<T> Failure(ErrorType errorType, string errorMessage)
    {
        return new TResult<T>
        {
            Errors = new List<Error>
            {
                new Error
                {
                    Type = errorType,
                    ErrorMessage = errorMessage
                }
            }
        };
    }

    public static TResult<T> Exception(string errorMessage)
    {
        return new TResult<T>
        {
            Errors = new List<Error>
            {
                new Error
                {
                    Type = ErrorType.Exception,
                    ErrorMessage = errorMessage,
                }
            }
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
    InternalServerError = 5,
    Failure = 6,
    Exception = 7
}