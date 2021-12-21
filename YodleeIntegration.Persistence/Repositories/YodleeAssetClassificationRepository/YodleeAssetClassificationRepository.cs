using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeAssetClassificationRepository
{
    public class YodleeAssetClassificationRepository : GenericRepository<AssetClassification>, IYodleeAssetClassificationRepository
    {
        public YodleeAssetClassificationRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
