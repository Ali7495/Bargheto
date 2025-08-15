using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargheto.Application.DataTransferObjects.Tickets
{
    public class TicketInputDto
    {
        public int TicketStatusId { get; set; }
        public int TicketPriorityId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid CreatedByUserId { get; set; }
        public Guid? AssignedToUserId { get; set; }
    }
}
