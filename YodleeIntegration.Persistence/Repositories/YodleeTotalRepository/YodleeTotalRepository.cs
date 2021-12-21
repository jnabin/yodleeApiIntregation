using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeTotalRepository
{
    public class YodleeTotalRepository : GenericRepository<Total>, IYodleeTotalRepository
    {
        public YodleeTotalRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
