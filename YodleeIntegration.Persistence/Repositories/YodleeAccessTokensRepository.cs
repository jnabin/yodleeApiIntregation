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
    public class YodleeAccessTokensRepository : GenericRepository<AccessTokens>, IYodleeAccessTokensRepository
    {
        public YodleeAccessTokensRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
