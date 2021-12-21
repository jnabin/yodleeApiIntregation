using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeHistoricalBalanceAccountRepository
{
    public class YodleeAccountBalanceRepository : GenericRepository<AccountBalance>, IYodleeAccountBalanceRepository
    {
        public YodleeAccountBalanceRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}

