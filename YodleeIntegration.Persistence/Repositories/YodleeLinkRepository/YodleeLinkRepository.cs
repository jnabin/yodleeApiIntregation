using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeLinkRepository
{
    public class YodleeLinkRepository : GenericRepository<Link>, IYodleeLinkRepository
    {
        public YodleeLinkRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
