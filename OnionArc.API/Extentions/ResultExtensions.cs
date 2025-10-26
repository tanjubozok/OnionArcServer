using OnionArc.Application.Base;

namespace OnionArc.API.Extentions;

public static class ResultExtensions
{
    public static IResult ToHttpResult<T>(this BaseResult<T> result)
    {
        if (result.IsSuccess)
            return Results.Ok(result.Data);

        var firstError = result.Errors!.First();
        return firstError.Type switch
        {
            ErrorType.NotFound => Results.NotFound(result),
            ErrorType.Validation => Results.BadRequest(result),
            ErrorType.Conflict => Results.Conflict(result),
            ErrorType.Unauthorized => Results.Unauthorized(),
            ErrorType.Forbidden => Results.Forbid(),
            ErrorType.InternalServerError => Results.Problem(
                statusCode: 500,
                detail: firstError.ErrorMessage
            ),
            _ => Results.BadRequest(result)
        };
    }
}