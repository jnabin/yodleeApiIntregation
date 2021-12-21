using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeProfileRepository
{
    public class YodleeProfileRepository : GenericRepository<Profile>, IYodleeProfileRepository
    {
        public YodleeProfileRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
