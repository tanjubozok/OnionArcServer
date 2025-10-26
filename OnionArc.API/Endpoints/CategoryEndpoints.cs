using MediatR;
using OnionArc.API.Extentions;
using OnionArc.Application.Features.Categories.Commands;
using OnionArc.Application.Features.Categories.Queries;

namespace OnionArc.API.Endpoints;

public static class CategoryEndpoints
{
    public static void RegisterCategoryEndpoints(this IEndpointRouteBuilder routeBuilder)
    {
        var categories = routeBuilder.MapGroup("/categories").WithTags("Categories");

        categories.MapGet(string.Empty, async (IMediator mediator) =>
        {
            var response = await mediator.Send(new GetCategoryQuery());
            return response.ToHttpResult();
        });

        categories.MapPost(string.Empty, async (CreateCategoryCommand command, IMediator mediator) =>
        {
            var response = await mediator.Send(command);
            return response.ToHttpResult();
        });
    }
}