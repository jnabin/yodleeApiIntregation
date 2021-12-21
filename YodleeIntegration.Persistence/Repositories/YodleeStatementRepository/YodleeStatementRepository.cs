using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeStatementRepository
{
    public class YodleeStatementRepository : GenericRepository<Statement>, IYodleeStatementRepository
    {
        public YodleeStatementRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
