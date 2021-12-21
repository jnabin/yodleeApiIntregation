using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeDataExtractAmountRepository
{
    public class YodleeDataExtractAmountRepository : GenericRepository<YodleeAmount>, IYodleeDataExtractAmountRepository
    {
        public YodleeDataExtractAmountRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
