using Microsoft.Extensions.DependencyInjection;
using YodleeIntegration.Application.Repositories;

namespace YodleeIntegration.Persistence
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructureModule(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            return services;
        }
    }
}
