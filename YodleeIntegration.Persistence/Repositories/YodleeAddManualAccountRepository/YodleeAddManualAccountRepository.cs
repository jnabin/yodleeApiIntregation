using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeAddManualAccountRepository
{
    public class YodleeAddManualAccountRepository : GenericRepository<AddManualAccount>, IYodleeAddManualAccountRepository
    {
        public YodleeAddManualAccountRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
