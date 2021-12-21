using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeTransactionCategorizationRuleRepository
{

    public class YodleeTransactionCategorizationRuleRepository : GenericRepository<TransactionCategorizationRule>, IYodleeTransactionCategorizationRuleRepository
    {
        public YodleeTransactionCategorizationRuleRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
