using Bargheto.Domain.Entities.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargheto.Domain.Interfaces.Repositories.UserManagement
{
    public interface IUserReopsitory : IRepository<User>
    {
        Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken);
    }
}
