using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeCoverageRepository
{
    public class YodleeCoverageRepository : GenericRepository<Coverage>, IYodleeCoverageRepository
    {
        public YodleeCoverageRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
