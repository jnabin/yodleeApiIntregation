using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeHoldingRepository
{
    public class YodleeHoldingRepository : GenericRepository<Holding>, IYodleeHoldingRepository
    {
        public YodleeHoldingRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
