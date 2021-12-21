using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeAttributeRepository
{
    public class YodleeAttributeRepository : GenericRepository<Attribute>, IYodleeAttributeRepository
    {
        public YodleeAttributeRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
