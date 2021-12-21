using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeTransactionsSummaryRepository
{
    public class YodleeTransactionsSummaryRepository : GenericRepository<TransactionsSummary>, IYodleeTransactionsSummaryRepository
    {
        public YodleeTransactionsSummaryRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
