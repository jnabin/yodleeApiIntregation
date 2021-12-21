using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeSecurityHoldingRepository
{
    public class YodleeSecurityHoldingRepository : GenericRepository<SecurityHolding>, IYodleeSecurityHoldingRepository
    {
        public YodleeSecurityHoldingRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
