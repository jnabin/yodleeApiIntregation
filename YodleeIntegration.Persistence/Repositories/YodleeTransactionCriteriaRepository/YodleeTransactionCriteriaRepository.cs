using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeTransactionCriteriaRepository
{
    public class YodleeTransactionCriteriaRepository : GenericRepository<TransactionCriteria>, IYodleeTransactionCriteriaRepository
    {
        public YodleeTransactionCriteriaRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
