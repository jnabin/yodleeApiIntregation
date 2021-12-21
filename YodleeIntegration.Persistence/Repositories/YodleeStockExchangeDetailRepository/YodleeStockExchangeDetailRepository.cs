using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeStockExchangeDetailRepository
{
    public class YodleeStockExchangeDetailRepository : GenericRepository<StockExchangeDetail>, IYodleeStockExchangeDetailRepository
    {
        public YodleeStockExchangeDetailRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
