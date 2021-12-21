using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeUserDataRepository
{
    public class YodleeUserDataRepository : GenericRepository<UserData>, IYodleeUserDataRepository
    {
        public YodleeUserDataRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
