using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeDataExtractUserRepository
{
    public class YodleeDataExtractUserRepository : GenericRepository<DataExtractUser>, IYodleeDataExtractUserRepository
    {
        public YodleeDataExtractUserRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
