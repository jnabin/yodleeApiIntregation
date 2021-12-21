using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeUpdateProviderAccountFieldRepository
{
    public class YodleeUpdateProviderAccountFieldRepository : GenericRepository<UpdateProviderAccountField>, IYodleeUpdateProviderAccountFieldRepository
    {
        public YodleeUpdateProviderAccountFieldRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
