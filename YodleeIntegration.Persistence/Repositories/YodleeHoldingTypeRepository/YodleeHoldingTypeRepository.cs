using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeHoldingTypeRepository
{
    public class YodleeHoldingTypeRepository : GenericRepository<HoldingType>, IYodleeHoldingTypeRepository
    {
        public YodleeHoldingTypeRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
