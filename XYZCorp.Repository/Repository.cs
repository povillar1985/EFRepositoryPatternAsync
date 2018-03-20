using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using XYZCorp.Core;

namespace XYZCorp.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected XYZDbContext _xYZDbContext;// = new XYZDbContext();

        public Repository()
        {
            _xYZDbContext = XYZDbContext.XYZDbCtx();
        }

        public void Add(TEntity entity)
        {
            _xYZDbContext.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _xYZDbContext.Set<TEntity>().AddRange(entities);
        }

        public async Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _xYZDbContext.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _xYZDbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _xYZDbContext.Set<TEntity>().FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            _xYZDbContext.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _xYZDbContext.Set<TEntity>().RemoveRange(entities);
        }

        public async Task SaveAsync()
        {
            await _xYZDbContext.SaveChangesAsync();
        }
    }
}
