using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeHoldingsAccountRepository
{
    public class YodleeHoldingsAccountRepository : GenericRepository<HoldingsAccount>, IYodleeHoldingsAccountRepository
    {
        public YodleeHoldingsAccountRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
