using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XYZCorp.Core.Domain;

namespace XYZCorp.Core.Repositories
{
    public interface IUserRepository: IRepository<User>
    {
        Task<List<User>> GetUserAdminsAsync();
        IEnumerable<User> GetUsersByPoints(int points);
    }
}
