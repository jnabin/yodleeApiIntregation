using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeProviderRepository
{
    public class YodleeProviderRepository : GenericRepository<Provider>, IYodleeProviderRepository
    {
        public YodleeProviderRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
