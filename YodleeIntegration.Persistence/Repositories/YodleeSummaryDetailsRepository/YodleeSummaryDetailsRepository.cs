using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeSummaryDetailsRepository
{
    public class YodleeSummaryDetailsRepository : GenericRepository<SummaryDetails>, IYodleeSummaryDetailsRepository
    {
        public YodleeSummaryDetailsRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
