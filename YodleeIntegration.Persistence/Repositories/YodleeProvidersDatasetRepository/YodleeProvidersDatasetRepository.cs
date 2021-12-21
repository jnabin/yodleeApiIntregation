using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeProvidersDatasetRepository
{
    public class YodleeProvidersDatasetRepository : GenericRepository<ProvidersDataset>, IYodleeProvidersDatasetRepository
    {
        public YodleeProvidersDatasetRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
