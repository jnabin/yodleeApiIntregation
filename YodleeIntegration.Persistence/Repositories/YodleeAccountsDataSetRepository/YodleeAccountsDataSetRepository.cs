using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeAccountsDataSetRepository
{
    public class YodleeAccountsDataSetRepository : GenericRepository<DataSet>, IYodleeAccountsDataSetRepository
    {
        public YodleeAccountsDataSetRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
