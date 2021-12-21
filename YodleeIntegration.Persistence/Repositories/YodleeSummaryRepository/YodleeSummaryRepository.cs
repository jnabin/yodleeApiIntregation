using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeSummaryRepository
{
    public class YodleeSummaryRepository : GenericRepository<Summary>, IYodleeSummaryRepository
    {
        public YodleeSummaryRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
