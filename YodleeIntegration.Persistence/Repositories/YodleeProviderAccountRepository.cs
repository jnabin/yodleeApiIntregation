 using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories
{
    public class YodleeProviderAccountRepository : GenericRepository<ProviderAccount>, IYodleeProviderAccountRepository
    {
        public YodleeProviderAccountRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
