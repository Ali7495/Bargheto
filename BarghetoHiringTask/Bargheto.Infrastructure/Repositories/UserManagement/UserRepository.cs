using Bargheto.Domain.Entities.UserManagement;
using Bargheto.Domain.Interfaces.Repositories.UserManagement;
using Bargheto.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
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

        public async Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return await Entities.AsNoTracking()
                .Include(u=> u.UserRoles)
                .ThenInclude(ur=> ur.Role)
                .FirstOrDefaultAsync(u => u.Email.Value == email, cancellationToken);
        }
    }
}
