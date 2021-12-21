using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeVerifyAccountDTORepository
{
    public class YodleeVerifyAccountDTORepository : GenericRepository<VerifyAccountDTO>, IYodleeVerifyAccountDTORepository
    {
        public YodleeVerifyAccountDTORepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
