using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Model.RequestLog;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.RequestLogRepository
{
    public class RequestLogRepository : GenericRepository<RequestLog>, IRequestLogRepository
    {
        public RequestLogRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}