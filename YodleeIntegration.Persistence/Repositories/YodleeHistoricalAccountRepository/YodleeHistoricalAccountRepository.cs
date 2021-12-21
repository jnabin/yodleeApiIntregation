using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeHistoricalAccountRepository
{
    public class YodleeHistoricalAccountRepository : GenericRepository<HistoricalAccount>, IYodleeHistoricalAccountRepository
    {
        public YodleeHistoricalAccountRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
