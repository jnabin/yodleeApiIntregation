using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeRowRepository
{
    public class YodleeRowRepository : GenericRepository<Row>, IYodleeRowRepository
    {
        public YodleeRowRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
