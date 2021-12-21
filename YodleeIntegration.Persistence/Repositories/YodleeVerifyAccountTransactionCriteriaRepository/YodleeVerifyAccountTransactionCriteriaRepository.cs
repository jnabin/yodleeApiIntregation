using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeVerifyAccountTransactionCriteriaRepository
{
    public class YodleeVerifyAccountTransactionCriteriaRepository : GenericRepository<VerifyAccountTransactionCriteria>, IYodleeVerifyAccountTransactionCriteriaRepository
    {
        public YodleeVerifyAccountTransactionCriteriaRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
