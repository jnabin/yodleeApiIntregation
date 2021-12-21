using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeDataExtractAccountRepository
{
    public class YodleeDataExtractAccountRepository : GenericRepository<DataExtractAccount>, IYodleeDataExtractAccountRepository
    {
        public YodleeDataExtractAccountRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
