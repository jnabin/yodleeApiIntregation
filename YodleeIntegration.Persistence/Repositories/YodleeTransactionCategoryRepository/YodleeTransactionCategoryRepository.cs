﻿using YodleeIntegration.Application.Repositories;
using YodleeIntegration.Domain.Entities;
using YodleeIntegration.Persistence.DbContexts;
using YodleeIntegration.Persistence.Repositories.GenericRepository;

namespace YodleeIntegration.Persistence.Repositories.YodleeTransactionCategoryRepository
{
    public class YodleeTransactionCategoryRepository : GenericRepository<TransactionCategory>, IYodleeTransactionCategoryRepository
    {
        public YodleeTransactionCategoryRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
