using OnionArc.Application.Results;
using System.Text.Json;

namespace OnionArc.API.CustomMiddlewares;

public class CustomExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public CustomExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (FluentValidation.ValidationException fex)
        {
            if (context.Response.HasStarted) throw;

            context.Response.Clear();
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = "application/json";

            var errors = fex.Errors?
                .Select(e => new Error
                {
                    PropertyName = e.PropertyName,
                    ErrorMessage = e.ErrorMessage,
                    Type = ErrorType.Validation
                })
                .ToList() ?? new List<Error>
                {
                    new Error { ErrorMessage = fex.Message, Type = ErrorType.Validation }
                };

            var response = TResult<object>.Failure(errors);

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            await context.Response.WriteAsync(JsonSerializer.Serialize(response, options));
        }
        catch (Exception ex)
        {
            if (context.Response.HasStarted) throw;

            context.Response.Clear();
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";

            var response = TResult<object>.Exception($"{ex.Message}");
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            await context.Response.WriteAsync(JsonSerializer.Serialize(response, options));
        }
    }
}