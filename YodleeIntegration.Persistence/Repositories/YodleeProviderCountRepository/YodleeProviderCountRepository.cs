using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeProviderCountRepository
{
    public class YodleeProviderCountRepository : GenericRepository<ProviderCount>, IYodleeProviderCountRepository
    {
        public YodleeProviderCountRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
