using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeAddManualResponseAccountRepository
{
    public class YodleeAddManualResponseAccountRepository : GenericRepository<AddManualResponseAccount>, IYodleeAddManualResponseAccountRepository
    {
        public YodleeAddManualResponseAccountRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
