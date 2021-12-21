using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeNameRepository
{
    public class YodleeNameRepository : GenericRepository<Name>, IYodleeNameRepository
    {
        public YodleeNameRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
