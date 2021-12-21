using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeProviderAccountPreferenceRepository
{
    public class YodleeProviderAccountPreferenceRepository : GenericRepository<ProviderAccountPreference>, IYodleeProviderAccountPreferenceRepository
    {
        public YodleeProviderAccountPreferenceRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
