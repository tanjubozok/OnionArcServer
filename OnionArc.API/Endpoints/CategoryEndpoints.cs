using MediatR;
using OnionArc.API.Extentions;
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
            return response.ToHttpResult();
        });
    }
}