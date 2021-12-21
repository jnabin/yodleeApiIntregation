using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeCoordinatesRepository
{
    public class YodleeCoordinatesRepository : GenericRepository<Coordinates>, IYodleeCoordinatesRepository
    {
        public YodleeCoordinatesRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
