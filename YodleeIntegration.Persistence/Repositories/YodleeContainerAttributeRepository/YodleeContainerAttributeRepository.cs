using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeContainerAttributeRepository
{
    public class YodleeContainerAttributeRepository : GenericRepository<ContainerAttribute>, IYodleeContainerAttributeRepository
    {
        public YodleeContainerAttributeRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
