using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories
{
    public class YodleeVerifiedAccountRepository : GenericRepository<VerifiedAccount>, IYodleeVerifiedAccountRepository
    {
        public YodleeVerifiedAccountRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
