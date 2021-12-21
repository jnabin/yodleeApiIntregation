using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeEventRepository
{
    public class YodleeEventRepository : GenericRepository<Event>, IYodleeEventRepository
    {
        public YodleeEventRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
