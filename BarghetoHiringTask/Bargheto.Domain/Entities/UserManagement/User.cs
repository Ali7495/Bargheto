using Bargheto.Domain.Entities.Tickets;
using Bargheto.Domain.ValurObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargheto.Domain.Entities.UserManagement
{
    public sealed class User : BaseEntity
    {
        public string FullName { get; set; } = string.Empty;
        public Email Email { get; set; } = Email.Create("test@email.com");
        public HashedPassword HashedPassword { get; set; } = HashedPassword.CheckHashed("password");


        public ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
        public ICollection<Ticket> CreatedTickets { get; set; } = new HashSet<Ticket>();
        public ICollection<Ticket> AssignedTickets { get; set; } = new HashSet<Ticket>();
    }
}
