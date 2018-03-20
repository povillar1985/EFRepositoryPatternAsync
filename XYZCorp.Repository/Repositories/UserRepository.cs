using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XYZCorp.Core.Domain;
using XYZCorp.Core.Repositories;

namespace XYZCorp.Repository.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(Func<XYZDbContext> xYZDbContext) : base(xYZDbContext)
        {
        }

        public async Task<List<User>> GetUserAdminsAsync()
        {
            return await _xYZDbContext.Users.Take(2).ToListAsync();
        }
    }
}
