using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeRewardBalanceRepository
{
    public class YodleeRewardBalanceRepository : GenericRepository<RewardBalance>, IYodleeRewardBalanceRepository
    {
        public YodleeRewardBalanceRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
