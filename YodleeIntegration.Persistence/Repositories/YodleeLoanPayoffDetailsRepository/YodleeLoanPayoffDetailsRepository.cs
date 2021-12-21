using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeLoanPayoffDetailsRepository
{
    public class YodleeLoanPayoffDetailsRepository : GenericRepository<LoanPayoffDetails>, IYodleeLoanPayoffDetailsRepository
    {
        public YodleeLoanPayoffDetailsRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
