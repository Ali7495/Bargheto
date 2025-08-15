using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargheto.Application.DataTransferObjects.Tickets
{
    public class TicketOutPutDto : BaseEntityDto
    {
        public string TicketStatus { get; set; }
        public string TicketPriority { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid CreatedByUserId { get; set; }
        public string UserCreatorEmail { get; set; }
        public Guid? AssignedToUserId { get; set; }
        public string? UserAssignedEmail { get; set; }

    }
}
