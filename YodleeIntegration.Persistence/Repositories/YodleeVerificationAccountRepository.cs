using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories
{
    public class YodleeVerificationAccountRepository : GenericRepository<VerificationAccount>, IYodleeVerificationAccountRepository
    {
        public YodleeVerificationAccountRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
