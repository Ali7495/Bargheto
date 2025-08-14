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
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(BarghetoDbContext dbContext) : base(dbContext)
        {
        }
    }
}
