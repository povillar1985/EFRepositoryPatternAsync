using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZCorp.Core
{
    public interface IRepository<TEntity> where TEntity: BaseEntity
    {
        
        Task<List<TEntity>> GetAllAsync();
        List<TEntity> GetAll();
        Task<TEntity> GetByIdAsync(int id);
        TEntity GetById(int id);
        Task SaveAsync();
    }
}
