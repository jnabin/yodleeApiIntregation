using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeApiKey
{
    public class YodleeApiKeyRepository : GenericRepository<Domain.Model.Authorizations.YodleeApiKey>, IYodleeApiKeyRepository
    {
        public YodleeApiKeyRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}