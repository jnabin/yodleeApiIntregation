using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeFullAccountNumberListRepository
{
    public class YodleeFullAccountNumberListRepository : GenericRepository<FullAccountNumberList>, IYodleeFullAccountNumberListRepository
    {
        public YodleeFullAccountNumberListRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
