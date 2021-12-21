using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeTransactionsLinkRepository
{
    public class YodleeTransactionsLinkRepository : GenericRepository<TransactionsLink>, IYodleeTransactionsLinkRepository
    {
        public YodleeTransactionsLinkRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
