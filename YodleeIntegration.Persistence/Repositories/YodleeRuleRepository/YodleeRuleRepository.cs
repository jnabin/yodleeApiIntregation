using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeRuleRepository
{
    public class YodleeRuleRepository : GenericRepository<Rule>, IYodleeRuleRepository
    {
        public YodleeRuleRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
