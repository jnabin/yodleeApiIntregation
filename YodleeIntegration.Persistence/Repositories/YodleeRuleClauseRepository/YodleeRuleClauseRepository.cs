using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeRuleClauseRepository
{
    public class YodleeRuleClauseRepository : GenericRepository<RuleClause>, IYodleeRuleClauseRepository
    {
        public YodleeRuleClauseRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
