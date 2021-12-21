using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories
{
    public class YodleeVerificationsRepository : GenericRepository<Verifications>, IYodleeVerificationsRepository
    {
        public YodleeVerificationsRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
