using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using YodleeIntegration.Domain.Model.Configurations;
using YodleeIntegration.Persistence.DbContexts;

namespace YodleeIntegration.Persistence.Seeders
{
    public static class YodleeConfigurationSeeder
    {
        public static async Task Run(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            await using var appContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            var yodleeConfiguration = new YodleeConfiguration
            {
                Url = "https://sandbox.api.yodlee.com.au/ysl",
                ClientId = "GwDjUXBhGuwYhitqRHDYdxXshQZeYSWt",
                Secret = "ahqHp8QHSnSuWLLU",
                ProviderId = "16441",
                ProviderAccountId = "10012606",
                AccountId = "10045607",
                RequestId = "1RZ0OH87GA3QnO4+rxsiweU8KbU=",
                ApiVersion = "1.1",
                IsActive = true
            };

            if (!await appContext.YodleeConfigurations.AnyAsync(x => x.ClientId.Equals(yodleeConfiguration.ClientId)))
            {
                await MarkOtherConfigurationsDeleted(appContext);
                await appContext.YodleeConfigurations.AddAsync(yodleeConfiguration);
                await appContext.SaveChangesAsync();
            }
        }

        private static async Task MarkOtherConfigurationsDeleted(ApplicationDbContext appContext)
        {
            if (appContext.YodleeConfigurations.Any())
            {
                var configurations = appContext.YodleeConfigurations;
                foreach (var configuration in appContext.YodleeConfigurations)
                {
                    configuration.IsActive = false;
                }
                appContext.YodleeConfigurations.UpdateRange(configurations);
                await appContext.SaveChangesAsync();
            }
        }
    }
}