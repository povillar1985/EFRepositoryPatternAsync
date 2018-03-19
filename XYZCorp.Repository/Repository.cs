using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        public async Task<List<TEntity>> GetAllAsync()
        {
            var result = await _xYZDbContext.Set<TEntity>().ToListAsync();
            return result;
        }

        public List<TEntity> GetAll()
        {
            var result = _xYZDbContext.Set<TEntity>().ToList();
            return result;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _xYZDbContext.Set<TEntity>().FindAsync(id);
        }

        public TEntity GetById(int id)
        {
            return _xYZDbContext.Set<TEntity>().Find(id);
        }

        public async Task SaveAsync()
        {
            using (var dbContext = _xYZDbContext)
            {
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
