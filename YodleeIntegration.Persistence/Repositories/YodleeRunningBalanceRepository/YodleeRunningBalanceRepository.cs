using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeRunningBalanceRepository
{
    public class YodleeRunningBalanceRepository : GenericRepository<RunningBalance>, IYodleeRunningBalanceRepository
    {
        public YodleeRunningBalanceRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
