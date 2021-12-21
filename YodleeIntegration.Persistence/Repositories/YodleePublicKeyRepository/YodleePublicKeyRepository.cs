using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleePublicKeyRepository
{
    public class YodleePublicKeyRepository : GenericRepository<PublicKey>, IYodleePublicKeyRepository
    {
        public YodleePublicKeyRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
