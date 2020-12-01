using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvPlusGame.DataAccess.Filters;
using TvPlusGame.Model.Entity;

namespace TvPlusGame.DataAccess.Repository
{
    public interface IBaseRepository<T> where T : class, IBaseEntity
    {
        Task<List<T>> GetAll();
        Task<List<T>> GetSome(PaginationFilter pagination);
        Task<int> GetCount();
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }
    public abstract class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
         where TEntity : class, IBaseEntity
         where TContext : DbContext
    {
        private readonly TContext context;
        public BaseRepository(TContext context)
        {
            this.context = context;
        }
        public async Task<TEntity> Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> Get(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().ToListAsync();
        }
        public async Task<List<TEntity>> GetSome(PaginationFilter pagination)
        {
            var entity = await context.Set<TEntity>().Skip((pagination.PageNumber - 1) * pagination.PageSize)
               .Take(pagination.PageSize).ToListAsync();

            return entity;
        }
        public async Task<int> GetCount()
        {
            var entity = await context.Set<TEntity>().CountAsync();

            return entity;
        }
        public async Task<TEntity> Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
