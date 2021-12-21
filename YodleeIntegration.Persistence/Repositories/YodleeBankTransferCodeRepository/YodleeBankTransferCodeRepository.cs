using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeBankTransferCodeRepository
{ 
    public class YodleeBankTransferCodeRepository : GenericRepository<BankTransferCode>, Application.Repositories.IYodleeBankTransferCodeRepository
    {
        public YodleeBankTransferCodeRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
