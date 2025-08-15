using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargheto.Application.DataTransferObjects.Tickets
{
    public class TicketCountStatusDto
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public int TicketCount { get; set; }
    }
}
