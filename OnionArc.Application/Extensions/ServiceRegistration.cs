﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace OnionArc.Application.Extensions;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
    }
}