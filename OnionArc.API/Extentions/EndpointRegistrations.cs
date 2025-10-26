using OnionArc.API.Endpoints;

namespace OnionArc.API.Extentions;

public static class EndpointRegistrations
{
    public static void RegisterEndpoints(this IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.RegisterCategoryEndpoints();
    }
}