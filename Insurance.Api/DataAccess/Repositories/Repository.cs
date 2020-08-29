using DataAccess.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        internal DataContext context;
        internal DbSet<T> dbSet;

        public Repository(DataContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task DeleteAsync(object id)
        {
            T result = await dbSet.FindAsync(id);
            dbSet.Remove(result);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
           return await dbSet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(T entity, object id)
        {
            var current = await dbSet.FindAsync(id);

            if (current != null)
            {
                
                dbSet.Attach(entity);
                context.Entry(current).CurrentValues.SetValues(entity);
                context.Entry(entity).State = EntityState.Modified;
            }
        }
    }
}
