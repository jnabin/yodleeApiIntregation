using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeIdentifierRepository
{
    public class YodleeIdentifierRepository : GenericRepository<Identifier>, IYodleeIdentifierRepository
    {
        public YodleeIdentifierRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
