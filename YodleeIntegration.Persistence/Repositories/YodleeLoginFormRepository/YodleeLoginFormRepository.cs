using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeLoginFormRepository
{
    public class YodleeLoginFormRepository : GenericRepository<LoginForm>, IYodleeLoginFormRepository
    {
        public YodleeLoginFormRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
