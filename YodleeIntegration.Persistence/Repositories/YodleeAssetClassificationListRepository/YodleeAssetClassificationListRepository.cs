using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeAssetClassificationListRepository
{
    public class YodleeAssetClassificationListRepository : GenericRepository<AssetClassificationList>, IYodleeAssetClassificationListRepository
    {
        public YodleeAssetClassificationListRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
