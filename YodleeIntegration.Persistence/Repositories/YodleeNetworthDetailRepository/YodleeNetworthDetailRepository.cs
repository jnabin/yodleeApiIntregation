using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeNetworthDetailRepository
{
    public class YodleeNetworthDetailRepository : GenericRepository<NetworthDetail>, IYodleeNetworthDetailRepository
    {
        public YodleeNetworthDetailRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
