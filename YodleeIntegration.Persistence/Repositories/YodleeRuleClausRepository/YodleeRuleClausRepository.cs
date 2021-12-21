using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeRuleClausRepository
{
    public class YodleeRuleClausRepository : GenericRepository<RuleClaus>, IYodleeRuleClausRepository
    {
        public YodleeRuleClausRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
