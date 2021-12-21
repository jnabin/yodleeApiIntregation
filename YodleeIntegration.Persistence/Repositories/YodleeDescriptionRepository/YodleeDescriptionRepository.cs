using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeDescriptionRepository
{
    public class YodleeDescriptionRepository : GenericRepository<Description>, IYodleeDescriptionRepository
    {
        public YodleeDescriptionRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
