using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeMerchantRepository
{
    public class YodleeMerchantRepository : GenericRepository<Merchant>, IYodleeMerchantRepository
    {
        public YodleeMerchantRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
