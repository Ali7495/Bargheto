using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bargheto.Domain.Entities.UserManagement;

namespace Bargheto.Domain.Entities.Tickets
{
    public sealed class Ticket : BaseEntity
    {
        public int TicketStatusId { get; set; }
        public int TicketPriorityId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid CreatedByUserId { get; set; }
        public Guid? AssignedToUserId { get; set; }


        public TicketStatus TicketStatus { get; set; }
        public TicketPriority TicketPriority { get; set; }
        public User CreatedByUser { get; set; }
        public User? AssignedToUser { get; set; }
    }
}
