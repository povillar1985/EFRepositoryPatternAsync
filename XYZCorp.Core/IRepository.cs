using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace XYZCorp.Core
{
    public interface IRepository<TEntity> where TEntity: BaseEntity
    {
        
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        Task SaveAsync();
    }
}
