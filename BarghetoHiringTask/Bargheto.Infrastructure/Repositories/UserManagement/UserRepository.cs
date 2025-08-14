using Bargheto.Domain.Entities.UserManagement;
using Bargheto.Domain.Interfaces.Repositories.UserManagement;
using Bargheto.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargheto.Infrastructure.Repositories.UserManagement
{
    public class UserRepository : Repository<User>, IUserReopsitory
    {
        public UserRepository(BarghetoDbContext dbContext) : base(dbContext)
        {
        }
    }
}
