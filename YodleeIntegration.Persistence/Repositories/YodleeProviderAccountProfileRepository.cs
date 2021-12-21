using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories
{
    public class YodleeProviderAccountProfileRepository : GenericRepository<ProviderAccountProfile>,
        IYodleeProviderAccountProfileRepository
    {
        public YodleeProviderAccountProfileRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
