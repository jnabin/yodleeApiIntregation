using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeUpdateProviderAccountAttributeRepository
{
    public class YodleeUpdateProviderAccountAttributeRepository : GenericRepository<UpdateProviderAccountAttribute>, IYodleeUpdateProviderAccountAttributeRepository
    {
        public YodleeUpdateProviderAccountAttributeRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
