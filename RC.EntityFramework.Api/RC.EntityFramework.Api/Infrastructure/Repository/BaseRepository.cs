using Microsoft.EntityFrameworkCore;
using RC.EntityFramework.Api.Core.Domains.Entitie;
using RC.EntityFramework.Api.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RC.EntityFramework.Api.Infrastructure.Repository
{
    public class BaseRepository<T> : IDisposable, IBaseRepository<T> where T : BaseEntitie
    {

        private readonly DbContext context;
        protected DbSet<T> DbSet => this.context.Set<T>();

        public BaseRepository(DbContext context)
        {
            this.context = context;
        }

        public async Task<T> GetAsync(int id)
        {
            return await FindAsync(x => x.Id == id);
        }

        public async Task InsertAsync(T entity)
        {
            DbSet.Add(entity);
            this.context.Entry(entity).State = EntityState.Added;
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            DbSet.Add(entity);
            this.context.Entry(entity).State = EntityState.Modified;
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteRowAsync(int id)
        {
            var entity = await FindAsync(x => x.Id == id);
            
            if (entity == null)
                return;

            if (this.context.Entry(entity).State == EntityState.Detached)
                DbSet.Attach(entity);

            DbSet.Remove(entity);
            await this.context.SaveChangesAsync();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

        public async Task<IEnumerable<T>> GetAllAsync(int pageSize, int pageActual)
        {
            return await this.context.Set<T>().OrderBy(x => x.Id).Skip((pageActual - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderExpression = null)
        {
            return await GetQuery(predicate, orderExpression).FirstOrDefaultAsync();
        }

        private IQueryable<T> GetQuery(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderExpression = null)
        {
            IQueryable<T> query = this.context.Set<T>();

            if (predicate != null)
                query = query.Where(predicate);

            if (orderExpression != null)
                return orderExpression(query);

            return query;
        }

    }
}