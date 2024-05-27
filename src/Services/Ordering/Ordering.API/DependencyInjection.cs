﻿using System.Reflection;

namespace Ordering.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            //services.AddCarter();

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            return services;
        }

        public static WebApplication UseApiServices(this WebApplication app)
        {
            //app.MapCarter();

            return app;
        }
    }
}
