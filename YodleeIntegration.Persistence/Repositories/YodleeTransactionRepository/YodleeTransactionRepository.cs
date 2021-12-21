using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeTransactionRepository
{
    public class YodleeTransactionRepository : GenericRepository<Transaction>, IYodleeTransactionRepository
    {
        public YodleeTransactionRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
