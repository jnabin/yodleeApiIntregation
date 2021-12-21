using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeHolderRepository
{
    public class YodleeHolderRepository : GenericRepository<Holder>, IYodleeHolderRepository
    {
        public YodleeHolderRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
