using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeHoldingsSummaryRepository
{
    public class YodleeHoldingsSummaryRepository : GenericRepository<HoldingsSummary>, IYodleeHoldingsSummaryRepository
    {
        public YodleeHoldingsSummaryRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
