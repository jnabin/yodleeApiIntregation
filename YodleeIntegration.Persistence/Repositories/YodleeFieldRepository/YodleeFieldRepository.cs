using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeFieldRepository
{
    public class YodleeFieldRepository : GenericRepository<Field>, IYodleeFieldRepository
    {
        public YodleeFieldRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
