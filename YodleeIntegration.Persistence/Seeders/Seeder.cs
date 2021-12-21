using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using YodleeIntegration.Persistence.DbContexts;

namespace YodleeIntegration.Persistence.Seeders
{
    public static class Seeder
    {
        public static IHost Seed(this IHost host)
        {
            var services = host.Services;
            using var scope = services.CreateScope();
            using var appContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            if (appContext.Database.GetPendingMigrations().Any())
            {
                appContext.Database.Migrate();
            }

            YodleeConfigurationSeeder.Run(services).Wait();

            return host;
        }
    }
}
