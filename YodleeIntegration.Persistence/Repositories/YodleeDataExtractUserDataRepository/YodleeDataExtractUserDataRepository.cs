using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeDataExtractUserDataRepository
{
    public class YodleeDataExtractUserDataRepository : GenericRepository<DataExtractUserData>, IYodleeDataExtractUserDataRepository
    {
        public YodleeDataExtractUserDataRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
