using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeAccountRepository
{
    public class YodleeAccountRepository : GenericRepository<Account>, IYodleeAccountRepository
    {
        public YodleeAccountRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
