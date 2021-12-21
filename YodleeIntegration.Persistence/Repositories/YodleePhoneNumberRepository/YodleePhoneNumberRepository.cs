using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleePhoneNumberRepository
{
    public class YodleePhoneNumberRepository : GenericRepository<PhoneNumber>, IYodleePhoneNumberRepository
    {
        public YodleePhoneNumberRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
