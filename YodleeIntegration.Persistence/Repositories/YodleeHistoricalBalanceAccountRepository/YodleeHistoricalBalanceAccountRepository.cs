using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeHistoricalBalanceAccountRepository
{
    public class YodleeHistoricalBalanceAccountRepository : GenericRepository<HistoricalBalanceAccount>, IYodleeHistoricalBalanceAccountRepository
    {
        public YodleeHistoricalBalanceAccountRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
