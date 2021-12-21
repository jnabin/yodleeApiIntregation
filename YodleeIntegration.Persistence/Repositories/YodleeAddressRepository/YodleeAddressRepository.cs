using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeAddressRepository
{
    public class YodleeAddressRepository : GenericRepository<Address>, IYodleeAddressRepository
    {
        public YodleeAddressRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
