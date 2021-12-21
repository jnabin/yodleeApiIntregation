using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeDetailCategoryRepository
{
    public class YodleeDetailCategoryRepository : GenericRepository<DetailCategory>, IYodleeDetailCategoryRepository
    {
        public YodleeDetailCategoryRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
