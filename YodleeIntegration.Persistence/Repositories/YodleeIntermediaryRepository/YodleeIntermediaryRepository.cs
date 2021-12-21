using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeIntermediaryRepository
{
    public class YodleeIntermediaryRepository : GenericRepository<Intermediary>, IYodleeIntermediaryRepository
    {
        public YodleeIntermediaryRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
