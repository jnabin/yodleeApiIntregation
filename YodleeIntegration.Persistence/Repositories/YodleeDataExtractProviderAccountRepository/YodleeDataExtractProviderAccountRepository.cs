using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeDataExtractProviderAccountRepository
{
    public class YodleeDataExtractProviderAccountRepository : GenericRepository<DataExtractProviderAccount>, IYodleeDataExtractProviderAccountRepository
    {
        public YodleeDataExtractProviderAccountRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
