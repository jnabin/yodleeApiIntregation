using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeUpdateProviderAccountDataSetRepository
{
    public class YodleeUpdateProviderAccountDataSetRepository : GenericRepository<UpdateProviderAccountDataSet>, IYodleeUpdateProviderAccountDataSetRepository
    {
        public YodleeUpdateProviderAccountDataSetRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
