using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeNotificationEventRepository
{
    public class YodleeNotificationEventRepository : GenericRepository<NotificationEvent>, IYodleeNotificationEventRepository
    {
        public YodleeNotificationEventRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
