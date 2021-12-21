using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories
{
    public class YodleeUserRepository : GenericRepository<Users>, IYodleeUserRepository
    {
        public YodleeUserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
