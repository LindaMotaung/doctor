﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

namespace Doctorly.Scheduler.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
