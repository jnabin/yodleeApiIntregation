using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeConfigurationRepository
{
    public class YodleeConfigurationRepository : GenericRepository<Domain.Model.Configurations.YodleeConfiguration>, IYodleeConfigurationRepository
    {
        public YodleeConfigurationRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
