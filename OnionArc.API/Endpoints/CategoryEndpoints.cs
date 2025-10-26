using MediatR;
using OnionArc.Application.Features.Categories.Queries;

namespace OnionArc.API.Endpoints;

public static class CategoryEndpoints
{
    public static void RegisterCategoryEndpoints(this IEndpointRouteBuilder routeBuilder)
    {
        var categories = routeBuilder.MapGroup("/categories").WithTags("Categories");

        categories.MapGet("", async (IMediator mediator) =>
        {
            var response = await mediator.Send(new GetCategoryQuery());

            return response.IsSuccess ? Results.Ok(response.Data) : Results.BadRequest(response.Data);
        });
    }
}