using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeDataExtractDatasetRepository
{
    public class YodleeDataExtractDatasetRepository : GenericRepository<DataExtractDataset>, IYodleeDataExtractDatasetRepository
    {
        public YodleeDataExtractDatasetRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
