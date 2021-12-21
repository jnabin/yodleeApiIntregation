using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeTypeRepository
{
    public class YodleeTypeRepository : GenericRepository<Domain.Entities.Type>, IYodleeTypeRepository
    {
        public YodleeTypeRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
