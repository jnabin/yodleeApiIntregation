using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace YodleeIntegration.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
