using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargheto.Domain.Entities.UserManagement
{
    public sealed class Role : BaseEntity
    {
        public string Name { get; set; } = string.Empty;


        public ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
    }
}
