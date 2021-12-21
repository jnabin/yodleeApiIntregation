using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeHistoricalBalanceRepository
{
    public class YodleeHistoricalBalanceRepository : GenericRepository<HistoricalBalance>, IYodleeHistoricalBalanceRepository
    {
        public YodleeHistoricalBalanceRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
