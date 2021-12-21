using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleePrincipalRepository
{
    public class YodleePrincipalRepository : GenericRepository<Principal>, IYodleePrincipalRepository
    {
        public YodleePrincipalRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
