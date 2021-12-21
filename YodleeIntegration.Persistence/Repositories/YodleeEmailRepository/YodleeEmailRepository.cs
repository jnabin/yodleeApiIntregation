using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;
namespace YodleeIntegration.Persistence.Repositories.YodleeEmailRepository
{
    public class YodleeEmailRepository : GenericRepository<Email>, IYodleeEmailRepository
    {
        public YodleeEmailRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
