using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Model.Authorizations;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeAccessTokenRepository
{
    public class YodleeAccessTokenRepository : GenericRepository<YodleeAccessToken>, IYodleeAccessTokenRepository
    {
        public YodleeAccessTokenRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
