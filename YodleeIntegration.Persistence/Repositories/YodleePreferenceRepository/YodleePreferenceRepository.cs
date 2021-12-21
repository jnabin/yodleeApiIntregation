using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleePreferenceRepository
{
    public class YodleePreferenceRepository : GenericRepository<Preference>, IYodleePreferenceRepository
    {
        public YodleePreferenceRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
