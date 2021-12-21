using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeCardDetailRepository
{
    public class YodleeCardDetailRepository : GenericRepository<CardDetail>, IYodleeCardDetailRepository
    {
        public YodleeCardDetailRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
