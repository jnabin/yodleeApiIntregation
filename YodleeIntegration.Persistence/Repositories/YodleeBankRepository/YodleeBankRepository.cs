using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeBankRepository
{
    public class YodleeBankRepository : GenericRepository<Bank>, IYodleeBankRepository
    {
        public YodleeBankRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
