using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace YodleeIntegration.Persistence.Repositories.Extensions
{
    public static class GenericRepositoryExtensions
    {
        public static IQueryable<TEntity> Include<TEntity>(this DbSet<TEntity> dbSet,
            params Expression<Func<TEntity, object>>[] includes)
            where TEntity : class
        {
            IQueryable<TEntity> query = null;
            foreach (var include in includes)
            {
                query = dbSet.Include(include);
            }

            return query ?? dbSet;
        }

        public static TEntity SingeOrDefault<TEntity>(this DbSet<TEntity> dbSet,
            Expression<Func<TEntity, bool>> condition)
            where TEntity : class
        {
            return dbSet.SingleOrDefault(condition);
        }

        public static async Task<TEntity> SingeOrDefaultAsync<TEntity>(this DbSet<TEntity> dbSet,
            Expression<Func<TEntity, bool>> condition)
            where TEntity : class
        {
            return await dbSet.SingleOrDefaultAsync(condition);
        }
    }
}
