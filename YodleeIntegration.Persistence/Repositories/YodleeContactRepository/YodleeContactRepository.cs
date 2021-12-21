using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeContactRepository
{
    public class YodleeContactRepository : GenericRepository<Contact>, IYodleeContactRepository
    {
        public YodleeContactRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
