using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeDataRepository
{
    public class YodleeDataRepository : GenericRepository<Data>, IYodleeDataRepository
    {
        public YodleeDataRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
