using OnionArc.Application.Results;

namespace OnionArc.API.Extentions;

public static class ResultExtensions
{
    public static IResult ToHttpResult<T>(this TResult<T> r)
    {
        if (r.IsSuccess) return Results.Ok(r.Data);
        var e = r.Errors!.First();
        return e.Type switch
        {
            ErrorType.Validation => Results.BadRequest(r),
            ErrorType.Unauthorized => Results.Unauthorized(),
            ErrorType.Forbidden => Results.Forbid(),
            ErrorType.NotFound => Results.NotFound(r),
            ErrorType.Conflict => Results.Conflict(r),
            ErrorType.InternalServerError or ErrorType.Failure or ErrorType.Exception
                => Results.Problem(statusCode: 500, detail: e.ErrorMessage),
            _ => Results.BadRequest(r)
        };
    }
}