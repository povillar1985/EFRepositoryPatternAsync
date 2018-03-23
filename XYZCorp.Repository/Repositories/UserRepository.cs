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
            //pretend that this is quering for list of admins
            return await _xYZDbContext.Users.Take(2).ToListAsync();
        }

        public IEnumerable<User> GetUsersByPoints(int points)
        {
            //this is the difference between IEnumerable and IQueryable
            //using IEnumerable is bad idea in this situation where we're accessing the database. 
            //IEnumerable will query all the records first in the database before it will executes the filter from the resultset object
            //Whereas, IQueryable will query the database including the filters we've requested

            //IEnumerable<User> users = _xYZDbContext.Users;
            IQueryable<User> users = _xYZDbContext.Users;
            return users.Where(x => x.Points == points);
        }
    }
}
