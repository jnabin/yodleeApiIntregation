using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeUpdateAccountDetailsRepository
{
    public class YodleeUpdateAccountDetailsRepository : GenericRepository<UpdateAccountDetails>, IYodleeUpdateAccountDetailsRepository
    {
        public YodleeUpdateAccountDetailsRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
